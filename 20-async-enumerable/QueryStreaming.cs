using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace async_enumerable
{
    public class Quote {
        public string Author { get; set; }
        public string Text { get; set; }
    }

    public class QuotesContext : DbContext
    {
        public DbSet<Quote> Quotes { get; set; }

        public QuotesContext()
        {
            Quotes.Add(new Quote {Author="John Smith", Text="I'm John Smith and I'm tall."});
            Quotes.Add(new Quote {Author="Michael de Santa", Text="You forget a thousand things every day..."});
            Quotes.Add(new Quote {Author="Geralt of Rivia", Text="I'm Geralt of Rivia. I'm a witcher."});
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseInMemoryDatabase("dummy_quotes");
    }

    public class QueryStreaming
    {
        private readonly QuotesContext quotesContext;

        public QueryStreaming(QuotesContext quotesContext)
        {
            this.quotesContext = quotesContext;
        }

        // public async IAsyncEnumerable<Quote> StreamQuotes()
        // {
        //     foreach (var quote in quotesContext.Quotes.AsAsyncEnumerable())
        //     {
        //         yield quote;
        //     }
        // }
    }
}
