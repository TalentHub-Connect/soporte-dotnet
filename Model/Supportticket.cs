using System;
using System.Collections.Generic;

namespace soporte_back_dotnet.Model
{
    public partial class Supportticket
    {
        public int Id { get; set; }
        public string? Tittle { get; set; }
        public string? Description { get; set; }
        public string? Ticketdate { get; set; }
        public string? Hour { get; set; }
        public string? Status { get; set; }
        public string? Answer { get; set; }
        public int? Companyid { get; set; }
        public int? Typesupportid { get; set; }
        public int? Userid { get; set; }
    }
}
