namespace EngieSingletonTest
{
    public class Tests
    {
     
        [Test]
        public void GivenDictionaryCacheWhenAStaticPropertyIsCalledThenClassIsNotInstanciated()
        {

            //Arrange
            //Act
            var dictionayCacheStatus = DictionaryCache.ClassStatus;

            //Assert
            Assert.That(dictionayCacheStatus, Is.EqualTo(Status.NotInitialized));
        }

        [Test]
        public void GivenDictionaryCacheWhenInstanceIsCalledThenClassIsInstanciated()
        {

            //Arrange
            var cache1 = DictionaryCache.Instance;

            //Act
            var dictionayCacheStatus = DictionaryCache.ClassStatus;

            //Assert
            Assert.That(dictionayCacheStatus, Is.EqualTo(Status.Initialized));
        }

        [Test]
        public void GivenDictionaryCacheWhenUpdatedKeyThenUpdateIsWorking()
        {

            //Arrange
            var cache1 = DictionaryCache.Instance;

            //Act
            cache1.Add("1", "test");
            cache1.Add("1", "test2");

            //Assert
            Assert.That(cache1.Get("1"), Is.EqualTo("test2"));
        }

        [Test]
        public void GivenDictionaryCacheWhenTwoInstancesAreCalledThenDatasAreShared()
        {

            //Arrange
            var cache1 = DictionaryCache.Instance;
            var cache2 = DictionaryCache.Instance;

            //Act
            cache1.Add("1", "test");

            //Assert
            Assert.That(cache2.Get("1"), Is.EqualTo("test"));
        }
    }
}