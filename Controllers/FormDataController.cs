using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wefa.Models;
using wefa.ViewModels;

namespace wefa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormDataController : ControllerBase
    {
        private readonly FRMS_PRDContext _context;

        public FormDataController(FRMS_PRDContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public IEnumerable<Request> GetRequests()
        {
            List<Request> requests = new List<Request>();

            foreach (var trnFilingRequest in _context.TrnFilingRequest
                .Include(fr => fr.TrnFormFilingRequest)
                    .ThenInclude(ffr => ffr.DocumentType)
                .Include(fr => fr.TrnFilingRequestPolicyTypeXref)
                    .ThenInclude(frptx => frptx.PolicyType)
                .Include(fr => fr.PolicyClass)
                .Include(fr => fr.TrnFilingRequestReplaceFormXref)
                .OrderByDescending(fr => fr.FilingRequestId)
                .Take(100)
                .ToList())
            {
                Request request = new Request()
                {
                    FilingRequestId = trnFilingRequest.FilingRequestId,
                    FilingRequest = $"FFR-{trnFilingRequest.TrnFormFilingRequest.FirstOrDefault()?.EditionDate:yy}-{trnFilingRequest.FilingRequestId:00000}",
                    DocumentType = trnFilingRequest.TrnFormFilingRequest.FirstOrDefault()?.DocumentType?.Name,
                    PolicyClass = trnFilingRequest.PolicyClass?.Name,
                    PolicyType = trnFilingRequest.TrnFilingRequestPolicyTypeXref.FirstOrDefault()?.PolicyType?.Name,
                    BaseFormIdString = trnFilingRequest.TrnFormFilingRequest.FirstOrDefault()?.BaseFormIdString,
                    EditionDate = trnFilingRequest.TrnFormFilingRequest.FirstOrDefault()?.EditionDate.Value,
                    ShortName = trnFilingRequest.TrnFormFilingRequest.FirstOrDefault()?.ShortName,
                    Name = trnFilingRequest.TrnFormFilingRequest.FirstOrDefault()?.Name,
                    FrsName = "",
                    ReplacesExistingForm = trnFilingRequest.TrnFormFilingRequest.FirstOrDefault()?.ReplacesExistingForm,
                    ReplacesExistingFormName = trnFilingRequest.TrnFilingRequestReplaceFormXref.FirstOrDefault()?.BaseFormIdString,
                    ReplacesExistingFormEditionDate = trnFilingRequest.TrnFilingRequestReplaceFormXref.FirstOrDefault()?.EditionDate
                };

                requests.Add(request);
            }

            return requests;
        }
    }
}