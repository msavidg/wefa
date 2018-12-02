import { Formfilingrequest } from './formfilingrequest';

export interface Filingrequest {
    filingRequestId: number;
    filingRequestTypeId: number;
    filingRequestStatusId: number;
    submittedBy: string;
    submittedDate: Date;
    policyClassId: number;
    subject: string;
    auditLastModified: Date;
    auditLastModifiedBy: string;
    systemAffected: number;
    blockRelease: boolean;
    isActive: boolean;
    formFilingRequest: Formfilingrequest;
}
