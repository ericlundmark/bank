﻿using System.Linq;
using Bank.Models;

namespace Bank.Repositories
{
    public interface IProviderRepository
    {
        Provider Create(Provider provider);
        Provider Find(int id);
        Provider Find(string name);
        IQueryable<Provider> List();
        void Save(Provider provider);
        void Dispose(bool disposing);
        bool ProviderExists(int id);
    }
}