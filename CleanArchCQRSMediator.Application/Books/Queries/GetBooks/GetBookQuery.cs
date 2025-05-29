using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchCQRSMediator.Application.Books.Queries.GetBooks
{
    //public class GetBookQuery:IRequest<List<BookVm>>
    //{

    //}

    public record class GetBookQuery : IRequest<List<BookVm>>;
}
