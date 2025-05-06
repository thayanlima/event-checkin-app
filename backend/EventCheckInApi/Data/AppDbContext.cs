using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Community> Communities { get; set; }
    public DbSet<Person> People { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Community>().HasData(
    new Community { Id = 1, Name = "Conferência de Tecnologia" },
    new Community { Id = 2, Name = "Workshop de Desenvolvimento" },
    new Community { Id = 3, Name = "Feira de Startups" },
    new Community { Id = 4, Name = "Hackathon Global" }
    );

    modelBuilder.Entity<Person>().HasData(
    new Person { Id = 1, FirstName = "João", LastName = "Silva", Company = "Tech Corp", Title = "Desenvolvedor", CommunityId = 1 },
    new Person { Id = 2, FirstName = "Maria", LastName = "Souza", Company = "DevHouse", Title = "Product Manager", CommunityId = 2 },
    new Person { Id = 3, FirstName = "Carlos", LastName = "Pereira", Company = "InovaTech", Title = "CTO", CommunityId = 1 },
    new Person { Id = 4, FirstName = "Fernanda", LastName = "Dias", Company = "WebSolutions", Title = "Designer", CommunityId = 3 },
    new Person { Id = 5, FirstName = "Lucas", LastName = "Lima", Company = "CloudX", Title = "DevOps", CommunityId = 4 },
    new Person { Id = 6, FirstName = "Ana", LastName = "Costa", Company = "AppFlow", Title = "QA Engineer", CommunityId = 2 },
    new Person { Id = 7, FirstName = "Rafael", LastName = "Martins", Company = "BitWise", Title = "Engenheiro de Software", CommunityId = 1 },
    new Person { Id = 8, FirstName = "Juliana", LastName = "Oliveira", Company = "Tech Corp", Title = "Scrum Master", CommunityId = 3 },
    new Person { Id = 9, FirstName = "Marcos", LastName = "Ferreira", Company = "WebSolutions", Title = "Analista de Sistemas", CommunityId = 4 },
    new Person { Id = 10, FirstName = "Camila", LastName = "Rocha", Company = "DevHouse", Title = "Tech Lead", CommunityId = 2 }
    );

}
}