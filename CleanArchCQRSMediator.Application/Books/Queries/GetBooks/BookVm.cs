using CleanArchCQRSMediator.Application.Books.Common.Mappings;
using CleanArchCQRSMediator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchCQRSMediator.Application.Books.Queries.GetBooks
{
    //view model for book query
    public class BookVm : IMapFrom<Book>
    // by implementing IMapFrom<Book>, you're telling the system:
    //"This BookVm can be automatically mapped FROM a Book entity"
    //"Please configure AutoMapper to handle Book → BookVm conversion"
    {        
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public string ISBN { get; set; } = string.Empty;
    }
}
