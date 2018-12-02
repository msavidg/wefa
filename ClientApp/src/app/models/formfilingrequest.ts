export interface Formfilingrequest {
    formFilingRequestId: number;
    filingRequestId: number;
    documentTypeId: number;
    countryId: number;
    formClassId: number;
    name: string;
    description: string;
    formIdString: string;
    baseFormIdString: string;
    effectiveDate: Date;
    expiryDate: Date;
    editionDate: Date;
    canHaveMultiples: boolean;
    adobeId: string;
    appliesToSubmission: number;
    appliesToQuote: number;
    appliesToBinder: number;
    appliesToPolicy: number;
    appliesToEndorsement: number;
    isCommon: boolean;
    isPremiumBearing: boolean;
    includeTermsOnQB: boolean;
    includeTermsOnDecPage: boolean;
    orderWithinClass: number;
    broadens: boolean;
    restricts: boolean;
    clarifies: boolean;
    watermarkOnQuote: boolean;
    watermarkOnBinder: boolean;
    watermarkOnPolicy: boolean;
    watermarkOnEndorsement: boolean;
    hasUserFillIns: boolean;
    hasSystemFillIns: boolean;
    purposeOfForm: string;
    shortName: string;
    isNewForm: boolean;
    replacesExistingForm: boolean;
    replacesExistingFormEditionDate: Date;
    mandatory: boolean;
    optional: boolean;
    auditLastModified: Date;
    auditLastModifiedBy: string;
    retainUserFillIns: boolean;
    includeDataOnQuote: boolean;
    includeDataOnBinder: boolean;
    includeDataOnPolicy: boolean;
    includeDataOnEndorsement: boolean;
    bypassWorkFlow: boolean;
}
