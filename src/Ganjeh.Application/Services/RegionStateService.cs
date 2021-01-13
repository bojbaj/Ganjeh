using Ganjeh.Domain.Interfaces;
using Ganjeh.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;
using Ganjeh.Domain.Models;
using Ganjeh.Domain.Models.DTOs.Region;
using AutoMapper;
using Ganjeh.Application.i18n;

namespace Ganjeh.Application.Services
{
    public class RegionStateService : IRegionStateService
    {
        private readonly IRepository<RegionState> regionStateRepo;
        private readonly IMapper _mapper;

        public RegionStateService(IRepository<RegionState> regionStateRepo, IMapper mapper)
        {
            this.regionStateRepo = regionStateRepo;
            _mapper = mapper;
        }

        public async Task<TypedResult<ICollection<StateDTO>>> GetList(Guid CountryId, int pageSize = 0, int pageNumber = 0)
        {
            try
            {
                ICollection<RegionState> result = await regionStateRepo
                    .GetList(
                        condition: x => x.RegionCountryId.Equals(CountryId),
                        pageSize: pageSize,
                        pageNumber: pageNumber,
                        includes: $"{nameof(RegionCountry)}"
                        );
                return new TypedResult<ICollection<StateDTO>>(_mapper.Map<ICollection<StateDTO>>(result));
            }
            catch (Exception ex)
            {
                return new TypedResult<ICollection<StateDTO>>(ex);
            }
        }

        public async Task<TypedResult<StateDTO>> Add(RegionState regionState)
        {
            try
            {
                ICollection<RegionState> existsRecords = await regionStateRepo
                    .GetList(condition: x => x.RegionCountryId == regionState.RegionCountryId && x.Title.Equals(regionState.Title));

                if (existsRecords.Any())
                    throw new InvalidOperationException(ErrorMessages.THIS_RECORD_ALREADY_EXISTS);
                RegionState result = await regionStateRepo.Add(regionState);
                return new TypedResult<StateDTO>(_mapper.Map<StateDTO>(result));
            }
            catch (Exception ex)
            {
                return new TypedResult<StateDTO>(ex);
            }
        }

        public async Task<TypedResult<StateDTO>> Update(RegionState regionState)
        {
            try
            {
                if (regionState.Id.Equals(Guid.Empty))
                    throw new InvalidOperationException(ErrorMessages.ID_IS_REQUIRED);
                RegionState existsRecord = await regionStateRepo.FindById(regionState.Id);
                if (existsRecord == null)
                    throw new InvalidOperationException(ErrorMessages.THIS_RECORD_DOES_NOT_EXISTS);

                existsRecord.RegionCountryId = regionState.RegionCountryId;
                existsRecord.Title = regionState.Title;
                RegionState result = await regionStateRepo.Update(existsRecord);
                return new TypedResult<StateDTO>(_mapper.Map<StateDTO>(result));
            }
            catch (Exception ex)
            {
                return new TypedResult<StateDTO>(ex);
            }
        }

        public async Task<TypedResult<bool>> Remove(Guid Id)
        {
            try
            {
                RegionState existsRecord = await regionStateRepo.FindById(Id);
                if (existsRecord == null)
                    throw new InvalidOperationException(ErrorMessages.THIS_RECORD_DOES_NOT_EXISTS);
                Boolean result = await regionStateRepo.Delete(Id);
                return new TypedResult<Boolean>(result);
            }
            catch (Exception ex)
            {
                return new TypedResult<Boolean>(ex);
            }
        }
    }
}