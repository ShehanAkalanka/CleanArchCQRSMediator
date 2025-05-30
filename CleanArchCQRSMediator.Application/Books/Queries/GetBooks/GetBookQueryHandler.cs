using AutoMapper;
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
    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, List<BookViewModel>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }        public async Task<List<BookViewModel>> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            // 1️⃣ Get all books from repository
            var books = await _bookRepository.GetAllBooksAsync();

            // 2️⃣ Use AutoMapper to convert List<Book> to List<BookVm>
            // This works automatically because BookVm implements IMapFrom<Book>
            var bookList = _mapper.Map<List<BookViewModel>>(books);

            // 3️⃣ Return the mapped ViewModels
            return bookList;
        }
    }
}
