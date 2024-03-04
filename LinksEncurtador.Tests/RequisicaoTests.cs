using EncurtadorLinks.Models;
using EncurtadorLinks.Services;
using FluentAssertions;
using FluentAssertions.Equivalency;
using LinksEncurtador.Core.Controllers;
using LinksEncurtador.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace LinksEncurtador.Tests
{
    namespace MyProject.Tests
    {
        public class URLShorteningTests
        {
            [Fact]
            public async Task Deve_Gerar_URLsDiferentes()
            {
                // Arrange
                var options = new DbContextOptionsBuilder<AppDbContext>()
                    .UseInMemoryDatabase(databaseName: "TestDatabase")
                    .Options;

                using var context = new AppDbContext(options);
                var urlShortener = new URLShortening(context);

                // Act
                var code1 = await urlShortener.GenerateURL();
                var code2 = await urlShortener.GenerateURL();

                // Assert
                code1.Should().NotBeNullOrEmpty();
                code2.Should().NotBeNullOrEmpty();
                code1.Should().NotBe(code2);
            }

            [Fact]
            public async Task Codigo_De_GerarURL_DeveTerSeteChars()
            {
                // Arrange
                var options = new DbContextOptionsBuilder<AppDbContext>()
                    .UseInMemoryDatabase(databaseName: "TestDatabase")
                    .Options;

                using var context = new AppDbContext(options);
                var urlShortener = new URLShortening(context);

                // Act
                var code = await urlShortener.GenerateURL();

                // Assert
                code.Should().HaveLength(7);
            }
        }
    }

}