using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperaCloud.Model.Reservas
{
    public class GetHotelReservations
    {
        /// <summary>
        /// Unique ID of the hotel where reservation is searched based on reservation ID.
        /// </summary>
        public string? hotelId { get; set; } = "GNQ";

        /// <summary>
        /// Mark this reservation as recently accessed.
        /// </summary>
        public bool? recentlyAccessed { get; set; } = null;

        /// <summary>
        /// Indicates maximum number of records a Web Service should return.
        /// </summary>
        public int? limit { get; set; } = null;

        /// <summary>
        /// Index or initial index of the set(page) being requested. If the index goes out of the bounds of the total set count then no data will be returned.
        /// </summary>
        public int? offset { get; set; } = null;

        /// <summary>
        /// Represents Reservation search type
        /// </summary>
        public OperaCloud.Reservas2.SearchType? SearchType { get; set; } = null;

        /// <summary>
        /// Free form text field for searching all reservation fields
        /// </summary>
        public string? text { get; set; } = null;

        /// <summary>
        /// A unique identifying value assigned by the creating system. The ID attribute may be used to reference a primary-key value within a database or in a particular implementation.
        /// </summary>
        public IEnumerable<string>? reservationIdList { get; set; }

        /// <summary>
        /// A unique identifying value assigned by the creating system. The ID attribute may be used to reference a primary-key value within a database or in a particular implementation.
        /// </summary>
        public IEnumerable<string>? confirmationNumberList { get; set; }

    }
}
