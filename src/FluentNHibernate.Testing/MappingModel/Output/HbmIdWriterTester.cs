﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.MappingModel;
using FluentNHibernate.MappingModel.Output;
using NUnit.Framework;
using FluentNHibernate.MappingModel.Identity;
using NHibernate.Cfg.MappingSchema;
using Rhino.Mocks;

namespace FluentNHibernate.Testing.MappingModel.Output
{
    [TestFixture]
    public class HbmIdWriterTester
    {
        [Test]
        public void Should_produce_valid_hbm()
        {
            var id = new IdMapping { Generator = new IdGeneratorMapping()};
            var generatorWriter = MockRepository.GenerateStub<IHbmWriter<IdGeneratorMapping>>();
            generatorWriter.Expect(x => x.Write(id.Generator)).Return(new HbmGenerator { @class = "native"});
            var writer = new HbmIdWriter(null, generatorWriter);

            writer.ShouldGenerateValidOutput(id);
        }

        [Test]
        public void Should_write_the_attributes()
        {
            var testHelper = new HbmTestHelper<IdMapping, HbmId>();
            testHelper.Check(x => x.Name, "id1").MapsTo(x => x.name);

            var writer = new HbmIdWriter(null, null);
            testHelper.VerifyAll(writer);
        }

        [Test]
        public void Should_write_the_generator()
        {
            var hbmGenerator = new HbmGenerator();
            var idMapping = new IdMapping {Generator = new IdGeneratorMapping()};

            var generatorWriter = MockRepository.GenerateStub<IHbmWriter<IdGeneratorMapping>>();
            generatorWriter.Expect(x => x.Write(idMapping.Generator)).Return(hbmGenerator);
            var writer = new HbmIdWriter(null, generatorWriter);

            var hbmId = (HbmId)writer.Write(idMapping);

            hbmId.generator.ShouldEqual(hbmGenerator);
        }

        [Test]
        public void Should_write_the_columns()
        {
            var hbmColumn = new HbmColumn();
            var idMapping = new IdMapping(new ColumnMapping());

            var columnWriter = MockRepository.GenerateStub<IHbmWriter<ColumnMapping>>();
            columnWriter.Expect(x => x.Write(idMapping.Columns.First())).Return(hbmColumn);
            var writer = new HbmIdWriter(columnWriter, null);

            var hbmId = (HbmId)writer.Write(idMapping);

            hbmId.column.ShouldContain(hbmColumn);

        }

    }
}
