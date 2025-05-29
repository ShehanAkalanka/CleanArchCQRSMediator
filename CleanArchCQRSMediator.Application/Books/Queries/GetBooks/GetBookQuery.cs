using CleanArchCQRSMediator.Domain.Entity;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchCQRSMediator.Application.Books.Queries.GetBooks
{
    //public class GetBookQuery:IRequest<List<BookVm>>
    //{

    //}

    //Modern Record Approach:
    //    From MediatR - defines a request that returns a response
    //    Generic parameter<List<BookVm>> specifies the return type
    //    This query will return a list of BookVm(Book View Models)
    public record class GetBookQuery : IRequest<List<BookVm>>;
}
