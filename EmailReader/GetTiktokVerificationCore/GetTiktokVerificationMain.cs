using OpenPop.Mime;
using OpenPop.Pop3;
using System.Text;
using System.Text.RegularExpressions;

namespace GetTiktokVerificationCore
{
    public class GetTiktokVerificationMain
    {
        public static string GetVerificationCode(string username, string password)
        {
            StringBuilder verificationCode = new StringBuilder();
            try
            {
                Console.WriteLine($"Username: {username}");
                using (Pop3Client pop3Client = new Pop3Client()) //create an object for pop3client
                {
                    if (username.EndsWith("@gmail.com"))
                    {
                        pop3Client.Connect("pop.gmail.com", 995, true);
                    }
                    else
                    {
                        pop3Client.Connect("outlook.office365.com", 995, true);
                    }
                    pop3Client.Authenticate(username, password, AuthenticationMethod.UsernameAndPassword);

                    int count = pop3Client.GetMessageCount();
                    Console.WriteLine($"Total Messages: {count}");

                    int start = Math.Max(1, count - 99); // Ensure we don't go below 1
                    for (int i = count; i >= start; i--)
                    {
                        Message message = pop3Client.GetMessage(i);

                        string from = message.Headers.From.Address;
                        if (string.Equals(from, "noreply@account.tiktok.com", StringComparison.OrdinalIgnoreCase))
                        {
                            string subject = message.Headers.Subject;
                            if (subject.IndexOf("verification code", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                subject.IndexOf("mã TikTok", StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                Match match = Regex.Match(subject, @"\d+");
                                if (match.Success)
                                {
                                    verificationCode.Clear();
                                    verificationCode.Append(match.Value);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine($"Verification Code: {verificationCode}");
                Console.WriteLine("--------------------");
            }
            return verificationCode.ToString();
        }
    }
}
