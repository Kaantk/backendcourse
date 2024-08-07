using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoriesDal;

        public CategoryManager(ICategoryDal categoriesDal)
        {
            _categoriesDal = categoriesDal;
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoriesDal.Get(p => p.CategoryId == categoryId));
        }

        public IResult Add(Category category)
        {
            _categoriesDal.Add(category);
            return new SuccessResult(true, Messages.CategoryAdded);
        }

        public IResult Delete(Category category)
        {
            _categoriesDal.Delete(category);
            return new SuccessResult(true, Messages.CategoryDeleted);
        }

        public IResult Update(Category category)
        {
            _categoriesDal.Update(category);
            return new SuccessResult(true, Messages.CategoryUpdated);
        }

        public IDataResult<List<Category>> GetList()
        {
            return new SuccessDataResult<List<Category>>(_categoriesDal.GetList().ToList());
        }

        public IDataResult<List<Category>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Category>>(_categoriesDal.GetList(p => p.CategoryId == categoryId).ToList());
        }

    }
}
