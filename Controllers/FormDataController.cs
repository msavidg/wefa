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
        public TrnFilingRequest GetFilingRequest(int filingRequestId)
        {
            return _context.TrnFilingRequest.Include(fr => fr.TrnFormFilingRequest).FirstOrDefault(fr => fr.FilingRequestId == filingRequestId);
        }

        [HttpGet("[action]")]
        public IEnumerable<FRMSRequest> GetRequests()
        {
            List<FRMSRequest> requests = new List<FRMSRequest>();

            foreach (var trnFilingRequest in _context.TrnFilingRequest
                .Include(fr => fr.FilingRequestStatus)
                .Include(fr => fr.TrnFormFilingRequest)
                    .ThenInclude(ffr => ffr.DocumentType)
                .Include(fr => fr.TrnFilingRequestPolicyTypeXref)
                    .ThenInclude(frptx => frptx.PolicyType)
                .Include(fr => fr.PolicyClass)
                .Include(fr => fr.TrnFilingRequestReplaceFormXref)
                .Where(fr => fr.FilingRequestTypeId == 1)
                .OrderByDescending(fr => fr.FilingRequestId)
                //.Take(500)
                .ToList())
            {
                FRMSRequest frmsRequest = new FRMSRequest()
                {
                    FilingRequestId = trnFilingRequest.FilingRequestId,
                    FilingRequest = $"FFR-{trnFilingRequest.TrnFormFilingRequest.First().EditionDate:yy}-{trnFilingRequest.FilingRequestId:00000}",
                    FilingRequestStatus = trnFilingRequest.FilingRequestStatus?.Name,
                    DocumentType = trnFilingRequest.TrnFormFilingRequest.First().DocumentType?.Name,
                    PolicyClass = trnFilingRequest.PolicyClass?.Name,
                    PolicyType = String.Join(", ", trnFilingRequest.TrnFilingRequestPolicyTypeXref.Select(frptx => frptx.PolicyType.Name).OrderBy(e=>e).ToArray()),
                    BaseFormIdString = trnFilingRequest.TrnFormFilingRequest.First().BaseFormIdString,
                    EditionDate = trnFilingRequest.TrnFormFilingRequest.First().EditionDate.Value,
                    ShortName = trnFilingRequest.TrnFormFilingRequest.First().ShortName,
                    Name = trnFilingRequest.TrnFormFilingRequest.First().Name,
                    FrsName = "",
                    ReplacesExistingForm = trnFilingRequest.TrnFilingRequestReplaceFormXref.Any(),
                    ReplacesExistingFormName = trnFilingRequest.TrnFilingRequestReplaceFormXref.FirstOrDefault()?.BaseFormIdString,
                    ReplacesExistingFormEditionDate = trnFilingRequest.TrnFilingRequestReplaceFormXref.FirstOrDefault()?.EditionDate
                };

                requests.Add(frmsRequest);
            }

            return requests;
        }
    }
}