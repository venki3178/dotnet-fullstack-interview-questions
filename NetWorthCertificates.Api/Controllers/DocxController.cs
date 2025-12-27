using Microsoft.AspNetCore.Mvc;
using NetWorthCertificates.Api.Dtos;
using Xceed.Words.NET;

[ApiController]
[Route("api/docx")]
public class DocxController : ControllerBase
{
    [HttpPost("generate")]
    public IActionResult Generate([FromBody] CertificateDto dto)
    {
        var templatePath = "Templates/Networth.docx";
        var doc = DocX.Load(templatePath);
        ////Main section
        //doc.ReplaceText("{{certificateName}}", dto.CertificateName);
        //doc.ReplaceText("{{cAName}}", dto.CAName);
        //doc.ReplaceText("{{salutation}}", dto.Salutation);
        //doc.ReplaceText("{{applicantName}}", dto.ApplicantName);
        //doc.ReplaceText("{{applicantFatherName}}", dto.ApplicantFatherName);
        //doc.ReplaceText("{{appliAddress}}", dto.ApplicantAddress);
        //doc.ReplaceText("{{passortNumber}}", dto.PassortNumber);
        //doc.ReplaceText("{{curSym}}", dto.CurrencySymbol);
        //doc.ReplaceText("{{curAmount}}", dto.CurAmount);

        ////doc.ReplaceText("{{fathSavAccAmount}}", dto.applicantSavingAccountAmount);
        //doc.ReplaceText("{{fatherAccBal}}", dto.applicantFatherSavingAccountBalance);
        //doc.ReplaceText("{{fathbusinessIn}}", dto.applicantFatherBusinessIncome);

        //doc.ReplaceText("{{Vehicle}}", dto.Vehicle);
        //doc.ReplaceText("{{propertyAddress}}", dto.propertyAddress);
        //doc.ReplaceText("{{propVlaue}}", dto.propertyValue);


        //doc.ReplaceText("{{PartnerNo}}", dto.PartnerNo);
        //doc.ReplaceText("{{UDIN}}", dto.UDIN);
        //doc.ReplaceText("{{Place}}", dto.Place);
        //doc.ReplaceText("{{Date}}", dto.Date);

        // Certificate Header
        doc.ReplaceText("{{certificateName}}", dto.CertificateName);
        doc.ReplaceText("{{salutation}}", dto.Salutation);

        // CA Details
        doc.ReplaceText("{{cAName}}", dto.CAName);
        doc.ReplaceText("{{partnerNo}}", dto.PartnerNo);
        doc.ReplaceText("{{UDIN}}", dto.UDIN);
        doc.ReplaceText("{{Place}}", dto.Place);
        doc.ReplaceText("{{Date}}", dto.Date);

        // Applicant Personal Details
        doc.ReplaceText("{{applicantName}}", dto.ApplicantName);
        doc.ReplaceText("{{applicantFatherName}}", dto.ApplicantFatherName);
        doc.ReplaceText("{{appliAddress}}", dto.ApplicantAddress);
        doc.ReplaceText("{{passortNumber}}", dto.PassortNumber);

        // Currency
        doc.ReplaceText("{{CS}}", dto.CurrencySymbol);
        doc.ReplaceText("{{CA}}", dto.CurAmount);

        // ==============================
        // ANNEXURE – 1 (SAVINGS IN INDIA)
        // ==============================

        doc.ReplaceText("{{FAB}}",dto.ApplicantFatherSavingAccountBalance);
        doc.ReplaceText("{{JA}}", dto.GoldJewelleryValue);
        int totalSavingsInIndia = int.Parse(dto.ApplicantFatherSavingAccountBalance) + int.Parse(dto.GoldJewelleryValue);
        doc.ReplaceText("{{TA1}}", totalSavingsInIndia.ToString());

        string FABOC = CalculateOtherCountryAmount(dto.ApplicantFatherSavingAccountBalance, dto.CurAmount);
        string JABOC = CalculateOtherCountryAmount(dto.GoldJewelleryValue, dto.CurAmount);
        string TA1OC = CalculateOtherCountryAmount(totalSavingsInIndia.ToString(), dto.CurAmount);
        doc.ReplaceText("{{FABOC}}", FABOC);
        doc.ReplaceText("{{JAOC}}",JABOC);
        doc.ReplaceText("{{TA1OC}}",TA1OC);

        // ==============================
        // ANNEXURE – 2 (INCOME FROM INDIA)
        // ==============================

        int fatherBusinessIncome = int.Parse(dto.ApplicantFatherBusinessIncome);
        doc.ReplaceText("{{FB}}",fatherBusinessIncome.ToString());
        doc.ReplaceText("{{TA2}}", fatherBusinessIncome.ToString());

        string FBOC = CalculateOtherCountryAmount(fatherBusinessIncome.ToString(),dto.CurAmount);
        doc.ReplaceText("{{FBOC}}",FBOC);
        doc.ReplaceText("{{TA2OC}}", FBOC);

        // ==============================
        // ANNEXURE – 3 (PROPERTIES IN INDIA)
        // ==============================

        doc.ReplaceText("{{propertyAddress}}", dto.PropertyAddress);
        doc.ReplaceText("{{Vehicle}}", dto.Vehicle);

        int propertyValue = int.Parse(dto.PropertyValue);
        int vehicleValue = int.Parse(dto.VehicleValue);
        int TA3 = int.Parse(dto.PropertyValue) + int.Parse(dto.VehicleValue);

        doc.ReplaceText("{{PV}}",propertyValue.ToString());
        doc.ReplaceText("{{VV}}", vehicleValue.ToString());
        doc.ReplaceText("{{TA3}}", TA3.ToString());

        string PVOC = CalculateOtherCountryAmount(propertyValue.ToString(),dto.CurAmount);
        string VVOC = CalculateOtherCountryAmount(vehicleValue.ToString(), dto.CurAmount);
        string TA3OC = CalculateOtherCountryAmount(TA3.ToString(), dto.CurAmount);

        doc.ReplaceText("{{PVOC}}", PVOC);
        doc.ReplaceText("{{VVOC}}", VVOC);
        doc.ReplaceText("{{TA3OC}}",TA3OC);

        // ==============================
        // SOURCE OF FUNDS – MAIN SUMMARY
        // ==============================

        int TotalNetWorth = totalSavingsInIndia + fatherBusinessIncome + TA3;
        doc.ReplaceText("{{TSIN}}",totalSavingsInIndia.ToString());
        doc.ReplaceText("{{TAIIN}}", fatherBusinessIncome.ToString());
        doc.ReplaceText("{{TPI}}",TA3.ToString());
        doc.ReplaceText("{{TNW}}",TotalNetWorth.ToString());


        string TSINOC = CalculateOtherCountryAmount(totalSavingsInIndia.ToString(), dto.CurAmount);
        string TAIINOC = CalculateOtherCountryAmount(fatherBusinessIncome.ToString(), dto.CurAmount);
        string TPIOC = CalculateOtherCountryAmount(TA3.ToString(), dto.CurAmount);
        string TNWOC = CalculateOtherCountryAmount(TotalNetWorth.ToString(),dto.CurAmount);

        doc.ReplaceText("{{TSINOC}}", TSINOC);
        doc.ReplaceText("{{TAIINOC}}", TAIINOC);
        doc.ReplaceText("{{TPIOC}}", TPIOC);
        doc.ReplaceText("{{TNWOC}}", TNWOC);

        var stream = new MemoryStream();
        doc.SaveAs(stream);
        stream.Position = 0;

        return File(
            stream,
            "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
            $"{dto.CertificateName}.docx"
        );
    }

    private string CalculateOtherCountryAmount(string amount, string curAmount)
    {
        return (Convert.ToInt32(amount) / Convert.ToInt32(curAmount)).ToString();
    }
}
