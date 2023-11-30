using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using Weesh.BusinessLogic;
using Weesh.DataAccess;
using Weesh.UserInterface;
public class Program
{
    private static void Main(string[] args)
    {
        ConsoleInput.SayHelloToUser();
        if (!Verification.IsArgsEmpty(args))
            Environment.Exit(0);
        foreach (var item in args)
        {
            if (!Verification.IsPathExists(item))
                Environment.Exit(0);
        }
        WorkWithFile workWithFile = new WorkWithFile();
        User user;
        Hire hire;
        Polling polling = new Polling();
        UserRequest userRequest;
        Equipment equipment;
        Payment payment;
        Check check = new Check();

        hire = workWithFile.InitializationHire(args[0], args[1]);
        if (!ConsoleInput.IsUserRegistered())
        {
            while (true)
            {
                try
                {
                    hire.GetNewUser(polling.GetLoginPassword());
                    break;
                }
                catch
                {
                    ConsoleInput.IncorrectLogin();
                }
            }

            while (true)
            {
                try
                {
                    user = hire.GetUser(polling.GetLoginPassword());
                    break;
                }
                catch
                {
                    ConsoleInput.IncorrectLoginOrPassword();
                }
            }
        }
        else
        {
            while (true)
            {
                try
                {
                    user = hire.GetUser(polling.GetLoginPassword());
                    break;
                }
                catch
                {
                    ConsoleInput.IncorrectLoginOrPassword();
                }
            }
        }
        userRequest = polling.CreateRequest();
        equipment = hire.GenerateUserEquipment(userRequest);
        ConsoleInput.ShowConfig(equipment);
        if (!Travel.ConfirmTravel())
        {
            ConsoleInput.OrderCancel();
            Environment.Exit(0);
        }
        if (!hire.IsFindScooter(equipment))
        {
            ConsoleInput.ScooterNotFound();
            Environment.Exit(0);
        }
        payment = workWithFile.InitializationPayment(args[2]);
        if (user.Subscription != null && Travel.ConfirmBonusDebit())
        {
            payment.CalculatePrice(userRequest, user);
        }
        else if (user.Subscription != null)
        {
            payment.CalculatePrice(userRequest);
            payment.CalculateDiscount(user.Subscription);
            user.GetBonusForTrip(payment.CalculateBonusForTrip(user.Subscription));
        }
        else
            payment.CalculatePrice(userRequest);
        check.CreateCheck(hire.IdOfScooter, userRequest.TimeStart, payment.ResultPrice);
        workWithFile.WriteFile(check.CheckForPerson, "./Check.txt");
        workWithFile.WriteFile(hire.DBScooter, workWithFile.DbScooterFilePath);
        workWithFile.WriteFile(hire.DBUsers, workWithFile.DbUsersFilePath);

        ConsoleInput.WishUserLuck();
    }
}