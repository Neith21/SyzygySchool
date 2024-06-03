namespace DEMO_PuellaSchoolAPP.Services.EMail
{
    public interface IEMailService
    {
        void SendEmail(string emailTo, string recepientName, string subject, string type);
    }
}
