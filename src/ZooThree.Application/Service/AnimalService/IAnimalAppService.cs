using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Service.Dto;

namespace ZooThree.Service.AnimalService
{
    public interface IAnimalAppService: IApplicationService
    {
        Task<AnimalDto> CreateAsync(AnimalDto input);
        Task<AnimalDto> GetAsync(Guid id);
        Task<List<AnimalDto>> GetAllAsync();
        Task<AnimalDto> UpdateAsync(AnimalDto input);
        Task Delete(Guid id);
    }
}
