using CleanArchCQRSMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchCQRSMediator.Application.Books.Queries.GetBooks
{
    //A Query Handler is the class that implements the business logic for processing a specific query.
    //It follows the Handler pattern from MediatR and is responsible for executing the "how" when a query asks "what".
    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, List<BookVm>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<List<BookVm>> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAllBooksAsync();


            //here we should add a auto mapper to map those easily
            var bookList = books.Select(b => new BookVm
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                PublishedDate = b.PublishedDate,
            }).ToList();

            return bookList;
        }
    }
}
