using DataLayer.DTO;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public interface ILikeService
    {
        Task<Like> AddLikeAsync(AddLikeDTO addLikeDTO);
    }
}
