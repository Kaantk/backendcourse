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
    public class CategoriesManager : ICategoriesService
    {
        private ICategoriesDal _categoriesDal;

        public CategoriesManager(ICategoriesDal categoriesDal)
        {
            _categoriesDal = categoriesDal;
        }

        public IDataResult<Categories> GetById(int categoryId)
        {
            return new SuccessDataResult<Categories>(_categoriesDal.Get(p => p.CategoryId == categoryId));
        }

        public IResult Add(Categories category)
        {
            _categoriesDal.Add(category);
            return new SuccessResult(true, Messages.CategoryAdded);
        }

        public IResult Delete(Categories category)
        {
            _categoriesDal.Delete(category);
            return new SuccessResult(true, Messages.CategoryDeleted);
        }

        public IResult Update(Categories category)
        {
            _categoriesDal.Update(category);
            return new SuccessResult(true, Messages.CategoryUpdated);
        }

        public IDataResult<List<Categories>> GetList()
        {
            return new SuccessDataResult<List<Categories>>(_categoriesDal.GetList().ToList());
        }

        public IDataResult<List<Categories>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Categories>>(_categoriesDal.GetList(p => p.CategoryId == categoryId).ToList());
        }

    }
}
