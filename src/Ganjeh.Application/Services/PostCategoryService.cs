using Ganjeh.Domain.Interfaces;
using Ganjeh.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;
using Ganjeh.Domain.Models;
using AutoMapper;
using Ganjeh.Application.i18n;
using Ganjeh.Domain.Models.DTOs.Post;
using Ganjeh.Domain.Models.Posts;

namespace Ganjeh.Application.Services
{
    public class PostCategoryService : IPostCategoryService
    {
        private readonly IRepository<PostCategory> postCategoryRepo;
        private readonly IMapper _mapper;

        public PostCategoryService(IRepository<PostCategory> postCategoryRepo, IMapper mapper)
        {
            this.postCategoryRepo = postCategoryRepo;
            _mapper = mapper;
        }

        public async Task<TypedResult<ICollection<PostCategoryDTO>>> GetAll()
        {
            try
            {
                ICollection<PostCategory> result = await postCategoryRepo.GetList();
                return new TypedResult<ICollection<PostCategoryDTO>>(_mapper.Map<ICollection<PostCategoryDTO>>(result));
            }
            catch (Exception ex)
            {
                return new TypedResult<ICollection<PostCategoryDTO>>(ex);
            }
        }
        public async Task<TypedResult<PostCategoryDTO>> Add(InsertPostCategory postCategory)
        {
            try
            {
                PostCategory existsRecord = (await postCategoryRepo.GetList(condition: x => x.Title.Equals(postCategory.Title))).FirstOrDefault();
                if (existsRecord != null)
                {
                    throw new InvalidOperationException(ErrorMessages.THIS_RECORD_ALREADY_EXISTS);
                }

                PostCategory entity = _mapper.Map<PostCategory>(postCategory);
                PostCategory result = await postCategoryRepo.Add(entity);
                return new TypedResult<PostCategoryDTO>(_mapper.Map<PostCategoryDTO>(result));
            }
            catch (Exception ex)
            {
                return new TypedResult<PostCategoryDTO>(ex);
            }
        }
        public async Task<TypedResult<PostCategoryDTO>> Update(UpdatePostCategory postCategory)
        {
            try
            {
                if (postCategory.Id.Equals(Guid.Empty))
                    throw new InvalidOperationException(ErrorMessages.ID_IS_REQUIRED);
                PostCategory existsRecord = await postCategoryRepo.FindById(postCategory.Id);
                if (existsRecord == null)
                    throw new InvalidOperationException(ErrorMessages.THIS_RECORD_DOES_NOT_EXISTS);

                existsRecord.Title = postCategory.Title;
                PostCategory result = await postCategoryRepo.Update(existsRecord);
                return new TypedResult<PostCategoryDTO>(_mapper.Map<PostCategoryDTO>(result));
            }
            catch (Exception ex)
            {
                return new TypedResult<PostCategoryDTO>(ex);
            }
        }
        public async Task<TypedResult<Boolean>> Remove(Guid Id)
        {
            try
            {
                PostCategory existsRecord = await postCategoryRepo.FindById(Id);
                if (existsRecord == null)
                    throw new InvalidOperationException(ErrorMessages.THIS_RECORD_DOES_NOT_EXISTS);
                Boolean result = await postCategoryRepo.Delete(Id);
                return new TypedResult<Boolean>(result);
            }
            catch (Exception ex)
            {
                return new TypedResult<Boolean>(ex);
            }
        }
   }
}