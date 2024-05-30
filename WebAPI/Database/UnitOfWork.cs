﻿using WebAPI.Database.Repository;

namespace WebAPI.Database
{
    public class UnitOfWork : IDisposable
    {
        private DataContext context = new DataContext();

        private IUserRepository? userRepository;
        private IStudentRepository? studentRepository;
        private ILehrenderRepository lehrenderRepository;
        public IStudentRepository StudentRepository
        {
            get
            {
                if (this.studentRepository == null)
                {
                    this.studentRepository = new StudentRepository(context);
                }
                return studentRepository;
            }
        }
        public ILehrenderRepository LehrenderRepository
        {
            get
            {
                if (this.lehrenderRepository == null)
                {
                    this.lehrenderRepository = new LehrenderRepository(context);
                }
                return lehrenderRepository;
            }
        }
        public IUserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(context);
                }
                return userRepository;
            }
        }
        private ISessionRepository? sessionRepository;

        public ISessionRepository SessionRepository
        {
            get
            {
                if (this.sessionRepository == null)
                {
                    this.sessionRepository = new SessionRepository(context);
                }
                return sessionRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
