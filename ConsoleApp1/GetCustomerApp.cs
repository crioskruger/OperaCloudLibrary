using OperaCloud.Customer.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class GetCustomerApp
    {
        private string tokenBearer = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsIng1dCI6IkRXWU14cE16QlYxd3hyZ21Xa0NSWVlfRW1kTSIsImtpZCI6Im1zLW9hdXRoa2V5In0.eyJzdWIiOiJSVklMQ0hFUyIsImlzcyI6Ind3dy5vcmFjbGUuY29tIiwib3JhY2xlLm9hdXRoLnN2Y19wX24iOiJPQXV0aFNlcnZpY2VQcm9maWxlIiwiaWF0IjoxNjU2Nzc0OTM3LCJvcmFjbGUub2F1dGgucHJuLmlkX3R5cGUiOiJMREFQX1VJRCIsImV4cCI6MTY1Njc3ODUzNywib3JhY2xlLm9hdXRoLnRrX2NvbnRleHQiOiJ1c2VyX2Fzc2VydGlvbiIsImF1ZCI6WyJodHRwczovLypvcmFjbGUqLmNvbSIsImh0dHBzOi8vKi5pbnQgIiwiaHR0cHM6Ly8qb2NzLm9jLXRlc3QuY29tLyJdLCJwcm4iOiJSVklMQ0hFUyIsImp0aSI6IjdkNGZjODU2LWU0YTUtNDVlZC1hOTI1LWZkNjdjNmYwODY4ZiIsIm9yYWNsZS5vYXV0aC5jbGllbnRfb3JpZ2luX2lkIjoiUkFfQ2xpZW50IiwidXNlci50ZW5hbnQubmFtZSI6IkRlZmF1bHREb21haW4iLCJvcmFjbGUub2F1dGguaWRfZF9pZCI6IjEyMzQ1Njc4LTEyMzQtMTIzNC0xMjM0LTEyMzQ1Njc4OTAxMiJ9.WSGokxG6m2wznOLRvzA4odSuJUr71Cujadm4xvt5UGYlLTbeJUe5Tm1uZdQVPUy9pAlUPkH3KyXplPN8rGWpGIMeqN4Ux0CzxuZTP0In4RwsLQfKt9ihIsptpPRByqOLCVUPlFKXLEnU1PFMvjRyMhzirREurEHte91bTxjTxutdyGgv9rbDSxL_PTI8GoxZ4tXa7yjBlFNOhOTE9ScmjUOexEhMyPA5-MS1dc81cS9aHc1xGsoflgHjxVK_Y0qU3TUEUx94UuzVVi8xXwPy17bgR5z1h2egBDa0OEDKXeIwV4pfbIo_SyX9VHP2yXdszDZ4m4GLZKksvXSuguwyvg";
        private string app_key = "742e1293-ce33-4d25-83d3-3f17af0a415b";
        private string hotelId = "GNQ";
        private string url_base = "https://mtucn1uat.hospitality-api.us-ashburn-1.ocs.oc-test.com/crm/v1";

        public async Task ObtenerGuestProfileAsync()
        {
            //OperaCloud.Customer.Client.Client client = new OperaCloud.Customer.Client.Client(url_base);

            //ICollection<Anonymous5> anonymous = new List<Anonymous5>();
            //Anonymous5 anonymous5 = Anonymous5.Profile;
            
            //anonymous.Add(anonymous5);

            //try
            //{
            //    //Se usa un Try Catch ya que cuando el GuestProfile no existe la llamada retorna un 204(NoContent) http error
            //    var res = await client.GetGuestProfileAsync("107540865", anonymous, tokenBearer, app_key, hotelId, "GNQ-API", "en-us");

            //    if (res == null)
            //        Console.WriteLine("Reservations Null");
            //    else
            //        Console.WriteLine($"{res.Links.Count} Links.");
            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            
        }

        public async Task CrearGuestProfileAsync()
        {
            //OperaCloud.Customer.Client.Client client = new OperaCloud.Customer.Client.Client(url_base);

            //Profile2 profile = new Profile2();

            //UniqueID_Type uniqueID_Type = new UniqueID_Type { Id = "10754086-5", Type = "RUT" };
            //ProfileIdList profileIdList = new ProfileIdList();
            //profileIdList.Add(uniqueID_Type);

            ////profile.ProfileIdList = profileIdList;

            //profile.ExternalReferences = new ExternalReferencesType();
            //profile.ExternalReferences.Add(new ExternalReferenceType { Id = "9" });

            //#region Crea un ProfileType del cliente

            //////Se crea al cliente.

            ////var personTypes = new List<PersonNameType>();
            ////var personType = new PersonNameType();
            ////personType.Surname = "Vilches";
            ////personType.Salutation = "";
            ////personType.GivenName = "Rogelio";
            ////personType.Language = "es-CL";
            ////personType.MiddleName = "";
            ////personType.NamePrefix = "Sr";
            ////personType.NameTitle = "";
            ////personType.Salutation = "Rogelius";

            ////var customer = new CustomerType();
            ////customer.PersonName = 

            ////profile.ProfileDetails = new ProfileType
            ////{
            ////    Customer = new CustomerType { }
            ////};


            //ICollection<PersonNameType> personTypes = new List<PersonNameType>();
            //var personType = new PersonNameType();
            //personType.Surname = "Vilches";
            ////personType.Salutation = "";
            //personType.GivenName = "Rogelio";
            ////personType.Language = "es-CL";
            ////personType.MiddleName = "";
            ////personType.NamePrefix = "Sr";
            ////personType.NameTitle = "";
            ////personType.Salutation = "Rogelius";
            ////personType.NameType = PersonNameTypeType.Primary;
            //personTypes.Add(personType);

            //var customer = new CustomerType();
            //customer.PersonName = personTypes;
            ////customer.CitizenCountry = new CountryNameType { Code = "CL", Value = "Chile" };

            //// IDENTIFICACION DEL CLIENTE
            //ICollection<IdentificationInfoType> infoTypes = new List<IdentificationInfoType>();
            //IdentificationInfoType identificationInfoType = new IdentificationInfoType();
            //IdentificationType identificationType = new IdentificationType();
            //identificationType.IdType = "RUT";
            //identificationType.IdNumber = "10754086-5";
            //identificationType.IdNumberMasked = "10754086-5";
            //identificationType.IssuedCountry = "Chile";
            //infoTypes.Add(identificationInfoType);

            //Identifications identifications = new Identifications();
            //identifications.IdentificationInfo = infoTypes;


            ////customer.Identifications = identifications;

            ////customer.BirthDate = DateTime.Now.AddYears(-50);
            //customer.Gender = CustomerTypeGender.Male;
            ////customer.Language = "es-CL";
            ////customer.Nationality = "CL";
            ////customer.NationalityDescription = "Chilena";
            ////customer.VipDescription = "Mi VIP Descripción";
            ////customer.VipStatus = "VipStatus";

            //ICollection<EmailInfoType> emailInfoTypes = new List<EmailInfoType>();
            //var emailInfoType = new EmailInfoType();
            //emailInfoType.Email = new EmailType { EmailAddress = "rogelio.vilches@gmail.com" };

            //emailInfoTypes.Add(emailInfoType);

            //var profileType = new ProfileType
            //{
            //    Customer = customer,
            //    Emails = new Emails2 { EmailInfo = emailInfoTypes },
            //    StatusCode = ProfileStatusType.Active
            //};


            //#endregion

            //profile.ProfileDetails = profileType;


            //var res = await client.PostProfileAsync(profile, tokenBearer, app_key, hotelId, "GNQ-API", "en-us");

            //if (res == null)
            //    Console.WriteLine("Reservations Null");
            //else
            //    Console.WriteLine($"{res.Links.Count} Links.");
        }
    }
}
