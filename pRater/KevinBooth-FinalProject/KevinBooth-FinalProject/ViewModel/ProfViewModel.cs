using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KevinBooth_FinalProject
{
    class ProfViewModel
    {
        ProfessorRater _context = new ProfessorRater();
        private ObservableCollection<PROFESSOR> Professor = new ObservableCollection<PROFESSOR>();
        private ObservableCollection<PROFRATING> ProfessorRating = new ObservableCollection<PROFRATING>();

        public ProfViewModel() {
            _context = new ProfessorRater();
        }

        public ObservableCollection<PROFESSOR> DisplayProfessors()
        {
            Professor.Clear();
            var profData = (from p in _context.PROFESSORs
                            orderby p.LastName
                            select p).ToList();

            profData.ForEach(x => Professor.Add(x));
            return Professor;
        }

        public ObservableCollection<PROFESSOR> SearchProfessor(string lastName, string dept)
        {
            Professor.Clear();
            if (lastName != "" && dept == "")
            {
                var prof = (from p in _context.PROFESSORs
                                where p.LastName.Equals(lastName)
                                orderby p.LastName
                                select p).ToList();
                prof.ForEach(x => Professor.Add(x));
                return Professor;
            }
            else if (lastName == "" && dept != "")
            {
                var prof = (from p in _context.PROFESSORs
                            where p.Department.Equals(dept)
                            orderby p.LastName
                            select p).ToList();
                prof.ForEach(x => Professor.Add(x));
                return Professor;
            }
            else if (lastName != "" && dept != "")
            {
                var prof = (from p in _context.PROFESSORs
                            where p.Department.Equals(dept) && p.LastName.Equals(lastName)
                            orderby p.LastName
                            select p).ToList();
                prof.ForEach(x => Professor.Add(x));
                return Professor;
            }
            else
            {
                var prof = (from p in _context.PROFESSORs
                            orderby p.LastName
                            select p).ToList();
                prof.ForEach(x => Professor.Add(x));
                return Professor;
            }
        }

        public ObservableCollection<PROFRATING> UpdateRatingTable(int pid)
        {
            ProfessorRating.Clear();

            var profData = (from p in _context.PROFRATINGs
                            join t in _context.PROFESSORs
                            on p.ProfessorId equals t.ProfessorId
                            where (t.ProfessorId.Equals(pid))
                            orderby p.UploadDate descending
                            select p).ToList();

            profData.ForEach(x => ProfessorRating.Add(x));
            return ProfessorRating;
        }

        public ObservableCollection<PROFRATING> DisplayRatings()
        {
            ProfessorRating.Clear();

            var profData = (from p in _context.PROFRATINGs
                            orderby p.UploadDate descending
                            select p).ToList();

            profData.ForEach(x => ProfessorRating.Add(x));
            return ProfessorRating;
        }

        public bool CreateNewRating(int pid, string classtaken, string com, bool book, string grade, int prof, int dif)
        {
            var rating = new PROFRATING
            {
                ProfessorId = pid,
                ClassTaken = classtaken,
                Comment = com,
                UseText = book,
                GradeReceived = grade,
                ProfRating1 = prof,
                DiffRating = dif,
                UploadDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
            };

            try
            {
                _context.PROFRATINGs.Add(rating);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("Can't write to db");
            }

            return true;
        }

        public string GetImageFile(int pid)
        {
            var profData = (from p in _context.PROFESSORs
                           where p.ProfessorId.Equals(pid)
                           select p.ProfileImage).SingleOrDefault();
            return profData;
        }

        public double GetRatingsAverage(int pid, int column)
        {
            var check = (from p in _context.PROFRATINGs
                         where p.ProfessorId.Equals(pid)
                         select p.ProfessorId).Count();
            if (check != 0)
            {
                var avg = (from p in _context.PROFRATINGs
                           where p.ProfessorId.Equals(pid)
                           select p.ProfRating1).Average();

                if (column == 2)
                {
                    avg = (from p in _context.PROFRATINGs
                           where p.ProfessorId.Equals(pid)
                           select p.DiffRating).Average();
                }

                return avg;
            }

            return check;
        }

        public bool AddProfessor(string first, string last, string dept)
        {
            var prof = new PROFESSOR
            {
                FirstName = first,
                LastName = last,
                Department = dept,
                ProfileImage = null
            };

            try
            {
                _context.PROFESSORs.Add(prof);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }

        public bool UpdateProfessor(int pid, string first, string last, string dept)
        {
            var result = _context.PROFESSORs.SingleOrDefault(n => n.ProfessorId.Equals(pid));

            if (result != null)
            {
                result.FirstName = first;
                result.LastName = last;
                result.Department = dept;

                try
                {
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    return false;
                }

                return true;
            }

            return false;
        }

        public bool DeleteProfessor(int pid)
        {
            var result = (from p in _context.PROFESSORs
                        where p.ProfessorId.Equals(pid)
                        select p).FirstOrDefault();

            if (result != null)
            {
                try
                {
                    _context.PROFESSORs.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        public bool DeleteRating(int rid)
        {
            var result = (from r in _context.PROFRATINGs
                          where r.RatingId.Equals(rid)
                          select r).FirstOrDefault();

            if (result != null)
            {
                try
                {
                    _context.PROFRATINGs.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }

            return true;
        }
    }
}
