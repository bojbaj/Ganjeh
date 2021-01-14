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
    public class PostService : IPostService
    {
        private readonly IRepository<Post> postRepo;
        private readonly IMapper _mapper;

        public PostService(IRepository<Post> postRepo, IMapper mapper)
        {
            this.postRepo = postRepo;
            _mapper = mapper;
        }

        public async Task<TypedResult<ICollection<PostDTO>>> GetList(Guid PostCategoryId, int pageSize = 0, int pageNumber = 0)
        {
            try
            {
                ICollection<Post> result = await postRepo.GetList(
                    condition: x => PostCategoryId.Equals(Guid.Empty) || x.PostCategoryId.Equals(PostCategoryId),
                    pageSize: pageSize,
                    pageNumber: pageNumber,
                    includes: $"{nameof(PostCategory)},{nameof(Address)},{nameof(Address)}.{nameof(RegionCity)},Video"
                );
                return new TypedResult<ICollection<PostDTO>>(_mapper.Map<ICollection<PostDTO>>(result));
            }
            catch (Exception ex)
            {
                return new TypedResult<ICollection<PostDTO>>(ex);
            }
        }
        public async Task<TypedResult<PostDTO>> Add(InsertPost post)
        {
            try
            {
                Post existsRecord = (await postRepo.GetList(condition: x => x.PostCategoryId.Equals(post.PostCategoryId) && x.Title.Equals(post.Title))).FirstOrDefault();
                if (existsRecord != null)
                {
                    throw new InvalidOperationException(ErrorMessages.THIS_RECORD_ALREADY_EXISTS);
                }

                Post entity = _mapper.Map<Post>(post);
                Post result = await postRepo.Add(entity);
                return new TypedResult<PostDTO>(_mapper.Map<PostDTO>(result));
            }
            catch (Exception ex)
            {
                return new TypedResult<PostDTO>(ex);
            }
        }
        public async Task<TypedResult<PostDTO>> Update(UpdatePost post)
        {
            try
            {
                if (post.Id.Equals(Guid.Empty))
                    throw new InvalidOperationException(ErrorMessages.ID_IS_REQUIRED);
                Post existsRecord = await postRepo.FindById(post.Id);
                if (existsRecord == null)
                    throw new InvalidOperationException(ErrorMessages.THIS_RECORD_DOES_NOT_EXISTS);

                existsRecord.Title = post.Title;
                Post result = await postRepo.Update(existsRecord);
                return new TypedResult<PostDTO>(_mapper.Map<PostDTO>(result));
            }
            catch (Exception ex)
            {
                return new TypedResult<PostDTO>(ex);
            }
        }
        public async Task<TypedResult<Boolean>> Remove(Guid Id)
        {
            try
            {
                Post existsRecord = await postRepo.FindById(Id);
                if (existsRecord == null)
                    throw new InvalidOperationException(ErrorMessages.THIS_RECORD_DOES_NOT_EXISTS);
                Boolean result = await postRepo.Delete(Id);
                return new TypedResult<Boolean>(result);
            }
            catch (Exception ex)
            {
                return new TypedResult<Boolean>(ex);
            }
        }
    }
}