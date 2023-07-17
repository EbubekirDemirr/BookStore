using AutoMapper;
using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Concrete.Models.CreateModels;
using Entities.Concrete.Models.DeleteModels;
using Entities.Concrete.Models.UpdateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IBookDal _bookDal;
        private readonly IUnitOfWorkDal _unitOfWorkDal;
        private readonly IMapper _mapper;
        public BookManager(IBookDal bookDal, IUnitOfWorkDal unitOfWorkDal, IMapper mapper)
        {
            _bookDal = bookDal;
            _unitOfWorkDal = unitOfWorkDal;
            _mapper = mapper;
        }
        public IResult CreateEntity(CreateBookDTO tEntity)
        {
            var mappedBook = _mapper.Map<Book>(tEntity);        
            _bookDal.Insert(mappedBook);
            _unitOfWorkDal.Save();
            return new SuccessResult(Messages.Created);
        }
        public IResult DeleteEntity(DeleteBookDTO tEntity)
        {
            var mappedBook = _mapper.Map<Book>(tEntity);
            _bookDal.Delete(mappedBook);
            _unitOfWorkDal.Save();
            return new SuccessResult(Messages.Deleted);
        }
        public IDataResult<Book> GetByIdEntity(int id)
        {
            return new SuccessDataResult<Book>(_bookDal.GetById(id));
        }
        public IResult UpdateEntity(UpdateBookDTO tEntity)
        {
            var mappedBook = _mapper.Map<Book>(tEntity);
            _bookDal.Update(mappedBook);
            _unitOfWorkDal.Save();
            return new SuccessResult(Messages.Updated);
        }
    }
}
