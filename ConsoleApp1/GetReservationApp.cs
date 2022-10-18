using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperaCloud.Reservas;

namespace ConsoleApp1
{
    public class GetReservationApp
    {
        //private string tokenBearer = "";
        private string app_key = "742e1293-ce33-4d25-83d3-3f17af0a415b";
        private string hotelId = "GNQ";
        private string url_base = "https://mtucn1uat.hospitality-api.us-ashburn-1.ocs.oc-test.com/rsv/v1";

        public async Task ObtenerReservationsAsync()
        {
            IEnumerable<string> reservationIdList = new string[] { "708811", "708835", "708153" };
            IEnumerable<string> confirmationNumberList = new string[] { "708811", "708835", "708153" };
            
            //IEnumerable<string> idExterno = new string[] { };
            //IEnumerable<string> cancel = new string[] { };
            //IEnumerable<string> externalRef = new string[] { };
            //IEnumerable<string> externalCod = new string[] { };
            //IEnumerable<string> companyname = new string[] { };
            //IEnumerable<string> null = new string[] { };

            Console.WriteLine("Obteniendo autorización...");
            var tokenApp = new ConsoleApp1.GetTokenApp();
            var tokenBearer = await tokenApp.ObtenerTokenAsync();

            OperaCloud.Reservas.Client client = new OperaCloud.Reservas.Client(url_base);

            OperaCloud.Reservas.ReservationsDetails res = await client.GetHotelReservationsAsync(hotelId, null, null, null, null, null, null, confirmationNumberList, null, null, null, null,
        null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
        null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
        null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
        null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
            tokenBearer,
            app_key, hotelId, "GNQ-API", "en-us");



            if (res.Reservations == null)
                Console.WriteLine("Reservations Null");
            else
                Console.WriteLine($"{res.Reservations.Count} reservas encontradas.");

        }

        public async Task CrearReservation()
        {
            // SE REGISTRA AL CLIENTE EN CADA HABITACION
            ICollection<PersonNameType> personTypes = new List<PersonNameType>();
            var personType = new PersonNameType();
            personType.Surname = "Vilches";
            personType.GivenName = "Rogelio";
            personType.Language = "E";
            personType.NameType = PersonNameTypeType.Primary;
            personTypes.Add(personType);

            var customer = new CustomerType();
            customer.PersonName = personTypes;
            customer.Language = "E";
            // FIN Cliente

            OperaCloud.Reservas.CreateReservation3 reservaContainer = new OperaCloud.Reservas.CreateReservation3();
            
           // HotelReservationsType Reservations: Collection of Reservations which have to be created

            HotelReservationsType reservationsToCreated = new HotelReservationsType();            
            ICollection<HotelReservationType> listaDeReservas = new List<HotelReservationType>();
            HotelReservationType newReserva = new HotelReservationType();

            newReserva.SourceOfSale = new SourceOfSaleType { SourceCode = "GNQ", SourceType = "PMS" };

            // ASIGANACION DE HABITACIÓN
            newReserva.RoomStayReservation = true;
            RoomStayType roomStayType = new RoomStayType();

            ICollection<RoomRateType> roomRates = new List<RoomRateType>();            
            RoomRateType roomRateType = new RoomRateType();
            roomRateType.Total = new TotalType { AmountBeforeTax = 180000, CurrencyCode = "CLP" };

            ICollection<AmountType> amountTypes = new List<AmountType>();
            AmountType amountType = new AmountType();
            amountType.Base = new TotalType
            {
                AmountBeforeTax = 180000,
                CurrencyCode = "CLP"
            };
            amountType.ShareDistributionInstruction = ShareDistributionInstructionType.Full;
            amountType.Total = new TotalType { AmountBeforeTax = 180000, CurrencyCode = "CLP" };
            amountType.Start = DateTimeOffset.Now;
            amountType.End = DateTimeOffset.Now.AddDays(30);
            amountTypes.Add(amountType);

            roomRateType.Rates = new RatesType 
            { 
                Rate = amountTypes 
            };
            roomRateType.GuestCounts = new GuestCountsType { Adults = 2, Children = 0 };
            roomRateType.RoomType = "SUPVM";
            roomRateType.RatePlanCode = "RPRODUCC";
            roomRateType.MarketCode = "HTL/TMO";
            roomRateType.MarketCodeDescription = "HTL/TMO";
            roomRateType.SourceCode = "DAOC";
            roomRateType.SourceCodeDescription = "DAOC";
            roomRateType.Start = DateTimeOffset.Now;
            roomRateType.End = DateTimeOffset.Now.AddDays(30);
            roomRateType.SuppressRate = true;
            roomRateType.NumberOfUnits = 1;
            roomRateType.PseudoRoom = false;
            roomRateType.RoomTypeCharged = "SUPVM";
            roomRateType.HouseUseOnly = false;
            roomRateType.Complimentary = false;
            roomRateType.FixedRate = true;
            roomRateType.DiscountAllowed = false;
            roomRateType.BogoDiscount = false;

            roomRates.Add(roomRateType);
            roomStayType.RoomRates = roomRates;

            roomStayType.GuestCounts = new GuestCountsType { Adults = 2, Children = 0 };
            roomStayType.ArrivalDate = DateTimeOffset.Now.AddDays(15);
            roomStayType.DepartureDate = DateTimeOffset.Now.AddDays(16);
            roomStayType.Guarantee = new ResGuaranteeType { GuaranteeCode = "OO-12340-678966", ShortDescription = "orden de compra" };
            roomStayType.RoomNumberLocked = false;
            roomStayType.PrintRate = false;
            
            newReserva.RoomStay = roomStayType;
            // FIN ASIGNACION DE HABITACION

            // PROFILE DE CLIENTE(s) PARA LA RESERVA
            ProfileInfo profileInfo = new ProfileInfo();
            profileInfo.Profile = new ProfileType { Customer = customer };

            ICollection<ResGuestType> clientesReserva = new List<ResGuestType>();
            ResGuestType clienteReserva = new ResGuestType();
            clienteReserva.ProfileInfo = profileInfo;
            clienteReserva.Primary = true;
            clientesReserva.Add(clienteReserva);
            newReserva.ReservationGuests = clientesReserva;

            // METODO DE PAGO
            ReservationPaymentMethodType metodoDePago = new ReservationPaymentMethodType();
            metodoDePago.PaymentMethod = "CASH";
            metodoDePago.FolioView = 1;
            ReservationPaymentMethodsType reservaMetodoDePago = new ReservationPaymentMethodsType();
            reservaMetodoDePago.Add(metodoDePago);
            newReserva.ReservationPaymentMethods = reservaMetodoDePago;

            // COMENTARIOS ASOCIADOS A LA RESERVA
            ICollection<CommentInfoType> commentInfoTypes = new List<CommentInfoType>();
            CommentInfoType commentInfoType = new CommentInfoType 
            { 
                Comment = new CommentType 
                { 
                    Text = new FormattedTextTextType { Value = "por favor necesitamos una cuna.", Language = "E" },
                     CommentTitle = "Notas Generales",
                     NotificationLocation = "RESERVATION",
                     Type = "GEN",
                     Internal = false
                } 
            };
            commentInfoTypes.Add(commentInfoType);
            newReserva.Comments = commentInfoTypes;


            // OTRAS PROPIEDADES DE LA RESERVA
            newReserva.ReservationStatus = PMS_ResStatusType.Reserved;
            newReserva.AdvanceCheckIn = new AdvanceCheckInType { AdvanceCheckedIn = false };
            newReserva.AllowMobileCheckout = false;
            newReserva.AllowMobileViewFolio = false;
            newReserva.ComputedReservationStatus = PMS_ResStatusType.DueIn;
            newReserva.HotelId = hotelId;
            newReserva.HasOpenFolio = false;
            newReserva.OptedForCommunication = false;
            newReserva.SharedGuests = new ResSharedGuestListType();
            
            //newReserva.Waitlist = new WaitlistResType();
            newReserva.WalkIn = false;
            newReserva.PrintRate = false;
            newReserva.PreRegistered = false;
            newReserva.UpgradeEligible = false;
            newReserva.AllowAutoCheckin = false;
            newReserva.AllowPreRegistration = false;


            // SE ADJUNTA LA RESERVA A UNA LISTA DE RESERVAS
            listaDeReservas.Add(newReserva);
            reservationsToCreated.Reservation = listaDeReservas;
            reservaContainer.Reservations = reservationsToCreated;

            ICollection<ReservationInstructionType> instructionTypes = new List<ReservationInstructionType>();
            instructionTypes.Add(ReservationInstructionType.Reservation);
            reservaContainer.FetchInstructions = instructionTypes;

            Console.WriteLine("Obteniendo autorización...");
            var tokenApp = new ConsoleApp1.GetTokenApp();
            var tokenBearer = await tokenApp.ObtenerTokenAsync();

            OperaCloud.Reservas.Client client = new OperaCloud.Reservas.Client(url_base);
            var res = await client.PostReservationAsync(hotelId, reservaContainer, tokenBearer, app_key, hotelId, "GNQ-API", "es-cl");

            if (res == null)
                Console.WriteLine("Reservations Null");
            else
                Console.WriteLine($"{res.Links.Count} links.");

        }

        public async Task GetReservationById()
        {
            Console.WriteLine("Obteniendo autorización...");
            var tokenApp = new ConsoleApp1.GetTokenApp();
            var tokenBearer = await tokenApp.ObtenerTokenAsync();

            IEnumerable<Anonymous16> fetchInstructions = new Anonymous16[] { };
            fetchInstructions.Append<Anonymous16>(Anonymous16.Reservation);

            IEnumerable<Anonymous17> allowedActions = new Anonymous17[] { };
            allowedActions.Append<Anonymous17>(Anonymous17.EnrollInProgress);

            OperaCloud.Reservas.Client client = new OperaCloud.Reservas.Client(url_base);
            var res = await client.GetReservationAsync("78778", hotelId, fetchInstructions, allowedActions, tokenBearer, app_key, hotelId, "GNQ-API", "es-cl");

            if (res == null)
                Console.WriteLine("Reservations Null");
            else
                Console.WriteLine($"{res.Links.Count} links.");
        }

        //public async Task CrearReservation2()
        //{
        //    #region TAXs
        //    // Es recomendable crear todos los TAX o cargos de la reserva inicialmente.
        //    ICollection<TaxType> taxTypesReservas = new List<TaxType>();
        //    TaxType taxTypeReserva = new TaxType
        //    {
        //        CurrencyCode = "CLP",
        //        Amount = 180000,
        //        Code = "BOL",
        //        Type = AmountDeterminationType.Exclusive,
        //        Description = "hotelería"
        //    };
        //    taxTypesReservas.Add(taxTypeReserva);

        //    ICollection<TaxType> taxTypesNoches = new List<TaxType>();
        //    TaxType taxTypeNoche = new TaxType
        //    {
        //        CurrencyCode = "CLP",
        //        Amount = 60000,
        //        Code = "BOL",
        //        Type = AmountDeterminationType.Inclusive,
        //        Description = "hotelería"
        //    };
        //    taxTypesNoches.Add(taxTypeNoche);

        //    ICollection<TaxesType> taxTaxesType = new List<TaxesType>();
        //    TaxesType taxesType = new TaxesType { Tax = taxTypesNoches, Amount = 180000, CurrencyCode = "CLP" };

        //    #endregion



        //    OperaCloud.Reservas2.CreateReservation3 reserva = new OperaCloud.Reservas2.CreateReservation3();

        //    #region HotelReservationsType Reservations: Collection of Reservations which have to be created

        //    reserva.Reservations = new HotelReservationsType();

        //    ICollection<HotelReservationType> hotelReservations = new List<HotelReservationType>();
        //    HotelReservationType hotelReservation = new HotelReservationType();

        //    // Used to provide PMS and/or CRS identifiers.
        //    // Este caso es nueva.
        //    //hotelReservation.ReservationIdList = new ReservationIdList();
        //    //hotelReservation.ReservationIdList.Add(new UniqueID_Type { Id = "101", Type = "Reservation" });

        //    //hotelReservation.ExternalReferences = new ExternalReferencesType();
        //    //hotelReservation.ExternalReferences.Add(new ExternalReferenceType { Id = "GNQ" });

        //    hotelReservation.RoomStay = new RoomStayType();
        //    //hotelReservation.RoomStay.RegistrationNumber = new UniqueID_Type { Id = "101", Type = "Reservation" };

        //    var agesTypes = new ChildAgesType();
        //    agesTypes.Add(new ChildAgeType { Age = 12 });
        //    var bucketsType = new ChildBucketsType();

        //    hotelReservation.RoomStay.CurrentRoomInfo = new CurrentRoomInfoType { RoomType = "SUPVM" };
        //    hotelReservation.RoomStay.GuestCounts = new GuestCountsType();
        //    hotelReservation.RoomStay.GuestCounts.Adults = 2;
        //    //hotelReservation.RoomStay.GuestCounts.ChildAges = agesTypes;
        //    //hotelReservation.RoomStay.GuestCounts.ChildBuckets = bucketsType;

        //    hotelReservation.RoomStay.ArrivalDate = DateTimeOffset.Now.AddDays(2);
        //    hotelReservation.RoomStay.DepartureDate = DateTimeOffset.Now.AddDays(4);

        //    hotelReservation.RoomStay.ExpectedTimes = new ResExpectedTimesType
        //    {
        //        ReservationExpectedArrivalTime = DateTimeOffset.UtcNow.AddDays(2),
        //        ReservationExpectedDepartureTime = DateTimeOffset.UtcNow.AddDays(4)
        //    };

        //    hotelReservation.RoomStay.OriginalTimeSpan = new TimeSpanType
        //    {
        //        StartDate = DateTimeOffset.Now.AddDays(2),
        //        EndDate = DateTimeOffset.Now.AddDays(4),
        //        Duration = "D"
        //    };

        //    hotelReservation.RoomStay.Guarantee = new ResGuaranteeType { GuaranteeCode = "codGar123" };
        //    hotelReservation.RoomStay.RoomNumberLocked = false;

        //    RoomRateType roomRateType = new RoomRateType();
        //    //roomRateType.Total = new TotalType();
        //    //roomRateType.Total.Taxes = new TaxesType { Amount = 200000, CurrencyCode = "CLP", Tax = taxTypesReservas };

        //    ICollection<AmountType> amountTypes = new List<AmountType>();
        //    AmountType amountType = new AmountType();
        //    amountType.Base = new TotalType
        //    {
        //        Taxes = new TaxesType { Tax = taxTypesNoches, Amount = 200000, CurrencyCode = "CLP" },
        //        Description = "noche hoteleria",
        //        CurrencyCode = "CLP",
        //        CurrencySymbol = "$",
        //        Code = "BOL"
        //    };
        //    //amountType.Discount = new DiscountType { Amount = 0, CurrencyCode = "CLP", DiscountCode = "", DiscountReason = "" };
        //    //amountType.Total = new TotalType { Taxes = taxesType, Code = "BOL", CurrencyCode = "CLP", CurrencySymbol = "$", Description = "Total taxs" };
        //    //amountType.EffectiveRate = new TotalType { Taxes = taxesType, Code = "BOL", CurrencyCode = "CLP", CurrencySymbol = "$", Description = "EffectiveRate" };
        //    amountTypes.Add(amountType);

        //    roomRateType.Rates = new RatesType { Rate = amountTypes };




        //    // SE REGISTRA AL CLIENTE EN CADA HABITACION
        //    ICollection<PersonNameType> personTypes = new List<PersonNameType>();
        //    var personType = new PersonNameType();
        //    personType.Surname = "Vilches";
        //    //personType.Salutation = "";
        //    personType.GivenName = "Rogelio";
        //    personType.Language = "E";
        //    //personType.MiddleName = "";
        //    //personType.NamePrefix = "Sr";
        //    //personType.NameTitle = "";
        //    //personType.Salutation = "Rogelius";
        //    personType.NameType = PersonNameTypeType.Primary;
        //    personTypes.Add(personType);

        //    var customer = new CustomerType();
        //    customer.PersonName = personTypes;

        //    //// IDENTIFICACION DEL CLIENTE
        //    //ICollection<IdentificationInfoType> infoTypes = new List<IdentificationInfoType>();
        //    //IdentificationInfoType identificationInfoType = new IdentificationInfoType();
        //    //IdentificationType identificationType = new IdentificationType();
        //    //identificationType.IdType = "RUT";
        //    //identificationType.IdNumber = "10754086-5";
        //    //identificationType.IdNumberMasked = "10754086-5";
        //    //identificationType.IssuedCountry = "Chile";
        //    //infoTypes.Add(identificationInfoType);

        //    //Identifications identifications = new Identifications();
        //    //identifications.IdentificationInfo = infoTypes;

        //    //customer.Identifications = identifications;
        //    customer.Identifications = new Identifications();

        //    //customer.BirthDate = DateTimeOffset.UtcNow.AddYears(-50);
        //    customer.Gender = CustomerTypeGender.Male;
        //    customer.Language = "E";
        //    //customer.Nationality = "CL";
        //    //customer.NationalityDescription = "Chilena";
        //    //customer.VipDescription = "Mi VIP Descripción";
        //    //customer.VipStatus = "VipStatus";

        //    ICollection<ReservationProfileType> reservationProfiles = new List<ReservationProfileType>();
        //    ICollection<EmailInfoType> emailInfoTypes = new List<EmailInfoType>();
        //    var emailInfoType = new EmailInfoType();
        //    emailInfoType.Email = new EmailType { EmailAddress = "rogelio.vilches@gmail.com" };

        //    emailInfoTypes.Add(emailInfoType);

        //    ICollection<ProfileCommissionType> commissionInfoLists = new List<ProfileCommissionType>();
        //    ICollection<TelephoneInfoType> telephoneInfoTypes = new List<TelephoneInfoType>();
        //    var telephoneInfoType = new TelephoneInfoType();
        //    telephoneInfoType.Telephone = new TelephoneType { PhoneNumber = "555555" };

        //    var profileType = new ProfileType
        //    {
        //        Customer = customer,
        //        Emails = new Emails2 { EmailInfo = emailInfoTypes },
        //        //Company = new CompanyType(),
        //        //ProfileImage = new ImageSetType(),
        //        //Addresses = new Addresses(),
        //        //Telephones = new Telephones2(),
        //        //URLs = new URLs(),
        //        //Comments = new Comments(),
        //        //ProfileDeliveryMethods = new ProfileDeliveryMethods(),
        //        //ProfileMemberships = new ProfileMemberships(),
        //        //PreferenceCollection = new PreferenceCollection(),
        //        //Relationships = new Relationships(),
        //        //RelationshipsSummary = new RelationshipsSummary(),
        //        //ReservationInfoList = new ReservationHistoryFutureInfoType(),
        //        //StayReservationInfoList = new ReservationStayHistoryFutureInfoType(),
        //        //LastStayInfo = new LastStayInfoType(),
        //        //ProfileRestrictions = new ProfileRestrictions(),
        //        //Cashiering = new ProfileCashieringType(),
        //        //CommissionInfoList = commissionInfoLists,
        //        //CreateDateTime = DateTime.Now,
        //        //CreatorId = "GNQ-API"
        //    };

        //    var reservationProfile = new ReservationProfileType { Profile = profileType, ReservationProfileType1 = ResProfileTypeType.Guest };
        //    reservationProfiles.Add(reservationProfile);

        //    roomRateType.StayProfiles = reservationProfiles;
        //    roomRateType.RoomType = "SUITVM";
        //    roomRateType.RatePlanCode = "RPRODUCC";
        //    roomRateType.MarketCode = "HTL/TMO";
        //    roomRateType.SourceCode = "DAOC";
        //    roomRateType.NumberOfUnits = 1;

        //    roomRateType.GuestCounts = new GuestCountsType { Adults = 2, Children = 0 };

        //    ICollection<RoomRateType> roomRates = new List<RoomRateType>();
        //    roomRates.Add(roomRateType);

        //    hotelReservation.RoomStay.RoomRates = roomRates;
        //    hotelReservation.HotelId = "GNQ";
        //    hotelReservation.RoomStayReservation = true;
        //    hotelReservation.ReservationStatus = PMS_ResStatusType.Reserved;
        //    hotelReservation.ComputedReservationStatus = PMS_ResStatusType.Reserved;
        //    //hotelReservation.CreateDateTime = DateTimeOffset.Now;
        //    //hotelReservation.LastModifyDateTime = DateTimeOffset.Now;
        //    //hotelReservation.CreateBusinessDate = DateTimeOffset.Now;
        //    //hotelReservation.LastModifierId = "RVILCHES";
        //    //hotelReservation.CreatorId = "RVILCHES";

        //    ICollection<ResGuestType> reservationsGuests = new List<ResGuestType>();
        //    ResGuestType resGuestType = new ResGuestType();

        //    UniqueID_Type uniqueID_Type = new UniqueID_Type { Id = "10754086-5", Type = "RUT" };

        //    ProfileInfo profileInfo = new ProfileInfo();
        //    ProfileIdList profileIdList = new ProfileIdList();
        //    profileIdList.Add(uniqueID_Type);

        //    //profileInfo.ProfileIdList = profileIdList;

        //    //profileInfo.Profile = new ProfileType { Customer = customer, Emails = new Emails2 { EmailInfo = emailInfoTypes } };
        //    profileInfo.Profile = new ProfileType { Customer = customer };

        //    resGuestType.ProfileInfo = profileInfo;
        //    //resGuestType.Primary = true;
        //    reservationsGuests.Add(resGuestType);


        //    ICollection<ReservationPaymentMethodType> paymentMethodTypes = new List<ReservationPaymentMethodType>();
        //    ReservationPaymentMethodType paymentMethodType = new ReservationPaymentMethodType();
        //    paymentMethodType.PaymentMethod = "CASH";
        //    //paymentMethodType.Description = "CASH - EFECTIVO";
        //    //paymentMethodType.AuthorizationRule = new AuthorizationRuleType { Amount = new CurrencyAmountType { Amount = 180000, CurrencyCode = "CLP" } };
        //    //paymentMethodType.Balance = new CurrencyAmountType { Amount = 180000, CurrencyCode = "CLP" };

        //    paymentMethodTypes.Add(paymentMethodType);

        //    hotelReservation.ReservationPaymentMethods = new ReservationPaymentMethodsType();
        //    hotelReservation.ReservationPaymentMethods.Add(paymentMethodType);
        //    hotelReservation.ReservationGuests = reservationsGuests;

        //    //hotelReservation.Queue = new ReservationQueueInformationType
        //    //{
        //    //    //TimeSpan = new OperaCloud.Reservas2.TimeSpan { StartDate = DateTime.Now.AddDays(2), EndDate = DateTime.Now.AddDays(4) },
        //    //    QueueDate = DateTime.Now
        //    //};

        //    hotelReservations.Add(hotelReservation);

        //    reserva.Reservations.Reservation = hotelReservations;
        //    #endregion

        //    #region ICollection<ReservationInstructionType> FetchInstructions: Instruction on what has to be fetched. Refer to Generic common types document

        //    ICollection<ReservationInstructionType> instructionTypes = new List<ReservationInstructionType>();
        //    instructionTypes.Add(ReservationInstructionType.Reservation);

        //    //reserva.FetchInstructions = instructionTypes;

        //    #endregion

        //    #region ReservationsInstructionsType ReservationsInstructionsType: Collection of Reservations which have to be created.

        //    ReservationsInstructionsType createdInstructionsType = new ReservationsInstructionsType
        //    {
        //        LinkReservations = new LinkReservationInstructionType(),
        //        ShareReservations = new ShareReservationInstructionType()
        //    };
        //    //reserva.ReservationsInstructionsType = createdInstructionsType;

        //    #endregion

        //    #region ChannelResvRQInfoType ChannelInformation: Channel specific information to be received in case the reservation is being created through a channel

        //    //ChannelResvRQInfoType channelResv = new ChannelResvRQInfoType();
        //    //channelResv.ChannelSummaryInfo = new ChannelSummaryInfoType();
        //    //channelResv.ChannelSummaryInfo.BookingChannel = new BookingChannelType();
        //    //channelResv.ChannelSummaryInfo.BookingChannel.ChannelCode = "API";
        //    //channelResv.ChannelSummaryInfo.BookingChannel.ChannelName = "APP de Test";

        //    //reserva.ChannelInformation = channelResv;

        //    #endregion

        //    Console.WriteLine("Obteniendo autorización...");
        //    var tokenApp = new ConsoleApp1.GetTokenApp();
        //    var tokenBearer = await tokenApp.ObtenerTokenAsync();

        //    OperaCloud.Reservas2.Client client = new OperaCloud.Reservas2.Client(url_base);
        //    var res = await client.HotelsReservationsPostAsync(hotelId, reserva, tokenBearer, app_key, hotelId, "GNQ-API", "es-cl");

        //    if (res.Result == null)
        //        Console.WriteLine("Reservations Null");
        //    else
        //        Console.WriteLine($"{res.Result.Links.Count} links.");

        //}
    }
}
