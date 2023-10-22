using BusinessObjects.DTOs;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class BirdDAO
    {
        private static BirdDAO instance = null!;
        private static readonly object instanceLock = new object();
        private readonly BirdFarmShopContext _context;

        public BirdDAO()
        {
            _context = new BirdFarmShopContext();
        }

        public static BirdDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BirdDAO();
                    }
                    return instance;
                }
            }
        }

        public List<BirdDTO> GetAllBirds()
        {


            var birds = _context.Birds.ToList();

            List<BirdDTO> birdList = new List<BirdDTO>();
            foreach (var bird in birds)
            {
                var _bird = new BirdDTO()
                {
                    BirdId = bird.BirdId,
                    BirdName = bird.BirdName,
                    Estimation = bird.Estimation,
                    Gender = bird.Gender,
                    WeightofBirds = bird.WeightofBirds,
                    BirdDescription = bird.BirdDescription,
                    BirdStatus = bird.BirdStatus,
                };

                birdList.Add(_bird);
            }


            return birdList;
        }

        public void AddNewBird(Bird bird)
        {
            try
            {
                _context.Add(bird);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Bird GetBirdByID(int id)
        {
            try
            {


                return _context.Birds.Include(x => x.BirdId).FirstOrDefault()!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateBird(Bird bird)
        {
            _context.Attach(bird).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (BirdExists(bird.BirdId))
                {
                    throw new Exception("Bird not exist");
                }
                throw;
            }
        }


        public void DeleteBird(int id)
        {
            try
            {
                var check = BirdExists(id);
                if (check)
                {
                    _context.Remove(check);
                    _context.SaveChanges();
                }
                throw new Exception("Bird not exist");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private bool BirdExists(int id)
        {
            return (_context.Birds?.Any(e => e.BirdId == id)).GetValueOrDefault();
        }


    }
}
