using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoriesService
    {
        IDataResult<Categories> GetById(int categoryId);
        IDataResult<List<Categories>> GetList();
        IDataResult<List<Categories>> GetListByCategory(int categoryId);
        IResult Add(Categories category);
        IResult Delete(Categories category);
        IResult Update(Categories category);
    }
}
