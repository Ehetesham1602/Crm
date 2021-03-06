﻿namespace Crm.Utilities
{
    public class Constants
    {
        public const string DateFormat = "MM/dd/yyyy";

        public const int DefaultPageSize = 10;

        public enum RecordStatus { Created, Active, Inactive, Deleted }
        public enum FieldTypeId { Text, Select, Radio, Checkbox }
        public enum EntityMasterId { Lead, Account, Opportunity }
        public enum LeadCallStatus { CallDone, CallReject, ReCall, NotDone}

        public struct Account
        {
            public const int AccountReceiveable = 1;
            public const int AccountPayable = 2;
        }

        public struct UserType
        {
            public const string Admin = "Administrator";
            public const string Employee = "Employee";
        }

        public struct EmailTemplateType
        {
            public const string ToCustomerOnRegistration = "to_customer_on_registration.html";
            public const string ToAdminOnCustomerRegistration = "to_admin_on_customer_registration.html";
        }
    }
}
