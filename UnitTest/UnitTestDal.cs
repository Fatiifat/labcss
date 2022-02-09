using ChoixSejour.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTest
{
    public class UnitTestDal
    {
        [Fact]
        public void Creation_Sejours_Verification()
        {
            // Nous supprimons la base si elle existe puis nous la créons
            using (Dal ctx = new Dal())
            {
                // Nous supprimons et créons la db avant le test
                ctx.DeleteCreateDatabase();
                // Nous créons un lieu de vacances
                ctx.CreerSejour("Chambord", "1111111111");

                // Nous vérifions que le lieu a bien été créé
                List<Sejour> sejours = ctx.ObtientTousLesSejours();
                Assert.NotNull(sejours);
                Assert.Single(sejours);
                Assert.Equal("Chambord", sejours[0].Lieu);
                Assert.Equal("1111111111", sejours[0].Telephone);
            }
        }

        [Fact]
        public void Modifier_Sejour_Verification()
        {
            // Nous supprimons la base si elle existe puis nous la créons
            using (Dal ctx = new Dal())
            {
                // Nous supprimons et créons la db avant le test
                ctx.DeleteCreateDatabase();
                // Nous créons un séjour
                int id = ctx.CreerSejour("Chambord", "1111111111");

                // Nous modifions le séjour grâce à notre nouvelle fonction
                ctx.ModifierSejour(id, "chenonceau", "2222222222");

                // nous vérifions que le séjour a bien été modifié
                List<Sejour> sejours = ctx.ObtientTousLesSejours();
                Assert.NotNull(sejours);
                Assert.Single(sejours);
                Assert.Equal("chenonceau", sejours[0].Lieu);
                Assert.Equal("2222222222", sejours[0].Telephone);
            }
        }

    }
}
