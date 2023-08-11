﻿using LoanAPI.Entites;

namespace LoanAPI.Service
{
    public interface IAdminService
    {
        void AddAdmin(AdminEntity admin);
        List<AdminEntity> GetAdmin();
        AdminEntity GetAdmin(string id);
        void EditAdmin(AdminEntity admin);
        void DeleteAdmin(string id);
    }
}