using System.Linq.Expressions;
using WMS.Application.DTOs.Responses;
using WMS.Application.Interfaces;
using WMS.Domain.Abstracts;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Application.Services
{
    public class CategoryService(IUnitOfWork _unitOfWork) : ICategoryService
    {
        public async Task<BaseResponse> AddAsync(Category model)
        {
            try
            {
                await _unitOfWork.BeginAsync();
                await _unitOfWork.CategoryRepository.AddAsync(model);
                await _unitOfWork.CommitAsync();
                return new BaseResponse();
            }
            catch (Exception ex)
            {
                return new BaseResponse(succeeded: false, message: "Something went wrong :(");
            }
        }

        public Task<BaseResponse> AddMultipleAsync(IEnumerable<Category> models)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> UpdateAsync(Category model)
        {
            var entity = _unitOfWork.CategoryRepository.FindAsync(model.Id);
            if (entity == null)
                return new BaseResponse(succeeded:false,message:"Not found!");
            try
            {
                await _unitOfWork.BeginAsync();
                _unitOfWork.CategoryRepository.Update(model);
                await _unitOfWork.CommitAsync();
                return new BaseResponse();
            }
            catch (Exception ex)
            {
                return new BaseResponse(succeeded: false, message: "Something went wrong :(");
            }
        }

        public async Task<BaseResponse> DeleteAsync(int id)
        {
            var model = await _unitOfWork.CategoryRepository.FindAsync(id);
            if (model == null)
                return new BaseResponse(false, "Not found!");
            try
            {
                await _unitOfWork.BeginAsync();
                _unitOfWork.CategoryRepository.Delete(model);
                    await _unitOfWork.CommitAsync();
                    return new BaseResponse();
            }
            catch (Exception ex)
            {
                return new BaseResponse(succeeded: false, message: "Something went wrong :(");
            }
        }

        public async Task<BaseResponse> FindAsync(int id)
        {
            var result = await _unitOfWork.CategoryRepository.FindAsync(id);
            if (result != null)
            {
                return new BaseResponse(data: result);
            }
            return new BaseResponse(succeeded: false, message: "Not found!");
        }

        public async Task<BaseResponse> GetListAsync(Expression<Func<Category, bool>> predicate = null!)
        {
            var result = await _unitOfWork.CategoryRepository.GetListAsync(predicate);
            if (result != null)
            {
                return new BaseResponse(data: result);
            }
            return new BaseResponse(succeeded: false, message: "Not found!");
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
