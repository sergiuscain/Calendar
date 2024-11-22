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
            Cards.Add(card);
            SaveChanges();
        }
        public void RemoveCard(Card card)
        {
            Cards.Remove(card);
            SaveChanges();
        }

        public Card TryFindCard(DateTime date)
        {
            var card = Cards.FirstOrDefault(x => x.Date == date);
            if (card == null)
            {
                card = new Card()
                {
                    Date = date,
                    Content = $" ",
                    Title = $" "
                };
                Cards.Add(card);
                SaveChanges();
            }
            return card;
        }
        public void UpdateCard(Card card)
        {
            var lastCard = TryFindCard(card.Date);
            if (lastCard != null)
            {
                lastCard = card;
                SaveChanges();
            }
        }
    }
}
