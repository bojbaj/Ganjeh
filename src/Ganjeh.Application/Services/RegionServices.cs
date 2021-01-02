using Ganjeh.Domain.Interfaces;
using Ganjeh.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;
using Ganjeh.Domain.Models;

namespace Ganjeh.Application.Services
{
    public class RegionServices : IRegionServices
    {
        private readonly IRepository<RegionCountry> regionCountryRepo;
        private readonly IRepository<RegionState> regionStateRepo;
        private readonly IRepository<RegionCity> regionCityRepo;
        public RegionServices(IRepository<RegionCountry> regionCountryRepo, IRepository<RegionState> regionStateRepo, IRepository<RegionCity> regionCityRepo)
        {
            this.regionCountryRepo = regionCountryRepo;
            this.regionStateRepo = regionStateRepo;
            this.regionCityRepo = regionCityRepo;
        }

        public async Task<TypedResult<ICollection<RegionCountry>>> GetCountries()
        {
            try
            {
                ICollection<RegionCountry> result = await regionCountryRepo.GetList();
                return new TypedResult<ICollection<RegionCountry>>(result);
            }
            catch (Exception ex)
            {
                return new TypedResult<ICollection<RegionCountry>>(false, ex.Message, null);
            }
        }
        public async Task<TypedResult<RegionCountry>> AddCountry(RegionCountry regionCountry)
        {
            try
            {
                RegionCountry existsRecord = (await regionCountryRepo.GetList(condition: x => x.Title.Equals(regionCountry.Title))).FirstOrDefault();
                if (existsRecord != null)
                    throw new InvalidOperationException("This country has exists!");
                RegionCountry result = await regionCountryRepo.Add(regionCountry);
                return new TypedResult<RegionCountry>(result);
            }
            catch (Exception ex)
            {
                return new TypedResult<RegionCountry>(false, ex.Message, null);
            }
        }
        public async Task<TypedResult<RegionCountry>> UpdateCountry(RegionCountry regionCountry)
        {
            try
            {
                if (regionCountry.Id.Equals(Guid.Empty))
                    throw new InvalidOperationException("Country id is required!");
                RegionCountry existsRecord = await regionCountryRepo.FindById(regionCountry.Id);
                if (existsRecord == null)
                    throw new InvalidOperationException("This country does not exists!");

                existsRecord.Title = regionCountry.Title;
                RegionCountry result = await regionCountryRepo.Update(existsRecord);
                return new TypedResult<RegionCountry>(result);
            }
            catch (Exception ex)
            {
                return new TypedResult<RegionCountry>(false, ex.Message, null);
            }
        }
        public async Task<TypedResult<Boolean>> RemoveCountry(Guid Id)
        {
            try
            {
                RegionCountry existsRecord = await regionCountryRepo.FindById(Id);
                if (existsRecord == null)
                    throw new InvalidOperationException("This country does not exists!");
                Boolean result = await regionCountryRepo.Delete(Id);
                return new TypedResult<Boolean>(result);
            }
            catch (Exception ex)
            {
                return new TypedResult<Boolean>(false, ex.Message, false);
            }
        }

        public async Task<TypedResult<ICollection<RegionState>>> GetStates(Guid CountryId, int pageSize = 0, int pageNumber = 0)
        {
            try
            {
                ICollection<RegionState> result = await regionStateRepo
                    .GetList(condition: x => x.RegionCountryId.Equals(CountryId), pageSize: pageSize, pageNumber: pageNumber);
                return new TypedResult<ICollection<RegionState>>(result);
            }
            catch (Exception ex)
            {
                return new TypedResult<ICollection<RegionState>>(false, ex.Message, null);
            }
        }

        public async Task<TypedResult<RegionState>> AddState(RegionState regionState)
        {
            try
            {
                ICollection<RegionState> existsRecords = await regionStateRepo
                    .GetList(condition: x => x.RegionCountryId == regionState.RegionCountryId && x.Title.Equals(regionState.Title));

                if (existsRecords.Any())
                    throw new InvalidOperationException("This state has exists!");
                RegionState result = await regionStateRepo.Add(regionState);
                return new TypedResult<RegionState>(result);
            }
            catch (Exception ex)
            {
                return new TypedResult<RegionState>(false, ex.Message, null);
            }
        }

        public async Task<TypedResult<RegionState>> UpdateState(RegionState regionState)
        {
            try
            {
                if (regionState.Id.Equals(Guid.Empty))
                    throw new InvalidOperationException("State id is required!");
                RegionState existsRecord = await regionStateRepo.FindById(regionState.Id);
                if (existsRecord == null)
                    throw new InvalidOperationException("This state does not exists!");

                existsRecord.RegionCountryId = regionState.RegionCountryId;
                existsRecord.Title = regionState.Title;
                RegionState result = await regionStateRepo.Update(existsRecord);
                return new TypedResult<RegionState>(result);
            }
            catch (Exception ex)
            {
                return new TypedResult<RegionState>(false, ex.Message, null);
            }
        }

        public async Task<TypedResult<bool>> RemoveState(Guid Id)
        {
            try
            {
                RegionState existsRecord = await regionStateRepo.FindById(Id);
                if (existsRecord == null)
                    throw new InvalidOperationException("This state does not exists!");
                Boolean result = await regionStateRepo.Delete(Id);
                return new TypedResult<Boolean>(result);
            }
            catch (Exception ex)
            {
                return new TypedResult<Boolean>(false, ex.Message, false);
            }
        }

        public async Task<TypedResult<ICollection<RegionCity>>> GetCities(Guid StateId, int pageSize = 0, int pageNumber = 0)
        {
            try
            {
                ICollection<RegionCity> result = await regionCityRepo
                    .GetList(condition: x => x.RegionStateId.Equals(StateId), pageSize: pageSize, pageNumber: pageNumber);
                return new TypedResult<ICollection<RegionCity>>(result);
            }
            catch (Exception ex)
            {
                return new TypedResult<ICollection<RegionCity>>(false, ex.Message, null);
            }
        }

        public async Task<TypedResult<RegionCity>> AddCity(RegionCity regionCity)
        {
            try
            {
                ICollection<RegionCity> existsRecords = await regionCityRepo
                    .GetList(condition: x => x.RegionStateId == regionCity.RegionStateId && x.Title.Equals(regionCity.Title));

                if (existsRecords.Any())
                    throw new InvalidOperationException("This state has exists!");
                RegionCity result = await regionCityRepo.Add(regionCity);
                return new TypedResult<RegionCity>(result);
            }
            catch (Exception ex)
            {
                return new TypedResult<RegionCity>(false, ex.Message, null);
            }
        }

        public async Task<TypedResult<RegionCity>> UpdateCity(RegionCity regionCity)
        {
            try
            {
                if (regionCity.Id.Equals(Guid.Empty))
                    throw new InvalidOperationException("State id is required!");
                RegionCity existsRecord = await regionCityRepo.FindById(regionCity.Id);
                if (existsRecord == null)
                    throw new InvalidOperationException("This state does not exists!");

                existsRecord.RegionStateId = regionCity.RegionStateId;
                existsRecord.Title = regionCity.Title;
                RegionCity result = await regionCityRepo.Update(existsRecord);
                return new TypedResult<RegionCity>(result);
            }
            catch (Exception ex)
            {
                return new TypedResult<RegionCity>(false, ex.Message, null);
            }
        }

        public async Task<TypedResult<bool>> RemoveCity(Guid Id)
        {
            try
            {
                RegionCity existsRecord = await regionCityRepo.FindById(Id);
                if (existsRecord == null)
                    throw new InvalidOperationException("This city does not exists!");
                Boolean result = await regionCityRepo.Delete(Id);
                return new TypedResult<Boolean>(result);
            }
            catch (Exception ex)
            {
                return new TypedResult<Boolean>(false, ex.Message, false);
            }
        }
    }
}