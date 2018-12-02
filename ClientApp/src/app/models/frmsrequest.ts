export interface FRMSRequest {
    filingRequestId: number;
    filingRequest: string;
    filingRequestStatus: string;
    documentType: string;
    policyClass: string;
    policyType: string;
    baseFormIdString: string;
    editionDate: Date;
    shortName: string;
    name: string;
    frsName: string;
    replacesExistingForm: boolean;
    replacesExisitingFormName: string;
    replacesExitingFormEditionDate: Date;
}
