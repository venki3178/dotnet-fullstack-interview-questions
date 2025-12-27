namespace NetWorthCertificates.Api.Dtos
{
    public class CertificateDto
    {
        // =========================
        // Certificate Meta
        // =========================
        public string CertificateName { get; set; }
        public string Salutation { get; set; }   // Mr / Ms / Mrs

        // =========================
        // Applicant Details
        // =========================
        public string ApplicantName { get; set; }
        public string ApplicantFatherName { get; set; }
        public string ApplicantAddress { get; set; }
        public string PassortNumber { get; set; }   // keeping your spelling
        public string CurrencySymbol { get; set; }
        public string ApplicantPropertyIncome { get; set; }
        public string CurAmount { get; set; }
        // =========================
        // Financial Summary
        // =========================
        public string ApplicantFatherSavingAccountBalance { get; set; }
        public string ApplicantFatherBusinessIncome { get; set; }

        // =========================
        // Annexure – 1 (Savings)
        // =========================
        public string GoldJewelleryValue { get; set; }

        // =========================
        // Annexure – 2 (Income)
        // =========================

        // =========================
        // Annexure – 3 (Properties)
        // =========================
        public string PropertyAddress { get; set; }
        public string PropertyValue { get; set; }
        public string Vehicle { get; set; }
        public string VehicleValue { get; set; }

        // =========================
        // CA / Firm Details
        // =========================
        public string CAName { get; set; }
        public string PartnerNo { get; set; }
        public string UDIN { get; set; }
        public string Place { get; set; }
        public string Date { get; set; }
    }


}
