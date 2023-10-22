using BusinessObjects.DTOs;
using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IBirdRepository
    {

        List<BirdDTO> GetAllBird();
        BirdDTO GetBirdDTOById(int id);
        Bird GetBirdById(int id);
        void AddNewBird(Bird bird);
        void UpdateBird(Bird bird);
        void DeleteBird(int id);

        
    }
}







