using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using vacay.Models;
using vacay.Interfaces;
using Dapper;

namespace vacay.Repositories
{
    public class VacationsRepository : IRepo<Vacation>

    {
        private readonly IDbConnection _db;

        public VacationsRepository(IDbConnection db)
        {
            _db = db;
        }

        public List<Vacation> GetAll()
        {
            string sql = @"
            SELECT
            a.*,
            v.*
            FROM vacations v
            JOIN accounts a ON a.id = v.creatorId";
            return _db.Query<Profile, Vacation, Vacation>(sql, (prof, vacay) =>
            {
               vacay.Creator = prof;
                return vacay;
            }).ToList();

        }
        public Vacation GetById(int id)
        {
            string sql = @"
            SELECT
            a.*,
            v.*
            FROM vacations v
            JOIN accounts a ON a.id = v.creatorId
            WHERE v.id = @id";
            return _db.Query<Profile, Vacation, Vacation>(sql, (prof, vacay) =>
            {
                vacay.Creator = prof;
                return vacay;
            }, new { id }).FirstOrDefault();
        }

        public Vacation Create(Vacation newVacation)
        {
            string sql = @"
            INSERT INTO vacations
            (name, description, creatorId, destination, imageUrl)
            VALUES
            (@Name, @Description, @CreatorId, @Destination, @ImageUrl);
            SELECT LAST_INSERT_ID();";
            newVacation.Id = _db.ExecuteScalar<int>(sql, newVacation);
            return newVacation;
        }

        public List<VacationCruiseViewModel> GetCruiseByAccountId(string userId)
        {
            string sql = @"
            SELECT
            a.*
            v.*
            c.id AS CruiseId
            FROM cruises c
            JOIN vacations v ON v.id = c.vacationId
            JOIN accounts a ON a.id = v.creatorId
            WHERE v.accountId = @userId";
            return _db.Query<Profile, VacationCruiseViewModel,  VacationCruiseViewModel>(sql, ( prof, vacay) =>
            {
                vacay.Creator = prof;
                return vacay;
            }, new { userId }).ToList();
        }
        public void Delete(int id)
        {
            string sql = @"
            DELETE FROM vacations
            WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });
        }
        
    }
}