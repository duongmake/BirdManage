using BusinessObjects.DTOs;
using BusinessObjects.Models;
using DataAccessObjects;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class BirdRepository : IBirdRepository
    {
        public void AddNewBird(Bird bird) => BirdDAO.Instance.AddNewBird(bird);
        

        public void DeleteBird(int id) => BirdDAO.Instance.DeleteBird(id);
      

        public List<BirdDTO> GetAllBird() => BirdDAO.Instance.GetAllBirds();
        

        public Bird GetBirdById(int id) => BirdDAO.Instance.GetBirdByID(id);    
       

        public BirdDTO GetBirdDTOById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateBird(Bird bird) => BirdDAO.Instance.UpdateBird(bird);
       
    }
}
