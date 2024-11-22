using Calendar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Services
{
    public class CardStorage : DbContext
    {
        public CardStorage() :base()
        {
            Database.EnsureCreated();
        }
        public DbSet<Card> Cards { get; set; }
        Random r = new Random();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Calendar;Trusted_Connection=True");
        }

        public void AddCard(Card card)
        {
            this.Cards.Add(card);
            this.SaveChanges();
        }
        public void RemoveCard(Card card)
        {
            this.Cards.Remove(card);
            this.SaveChanges();
        }

        public Card TryFindCard(DateTime date)
        {
            var card = this.Cards.FirstOrDefault(x => x.Date == date);
            if (card == null)
            {
                card = new Card()
                {
                    Date = date,
                    Content = $"TestContent{r.Next(100)}",
                    Title = $"TestTitle{r.Next(100)}"
                };
                this.Cards.Add(card);
                this.SaveChanges();
            }
            return card;
        }
    }
}
