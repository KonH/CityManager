using UnityEngine.Assertions;

namespace CityManager.Utils {
	public static class AssertExt {
		public static void IsNotNullOrWhiteSpace(string str) {
			Assert.IsTrue(!string.IsNullOrWhiteSpace(str), "Value was null or whitespace");
		}

		public static void IsNotEmpty<T>(T[] container) {
			Assert.IsNotNull(container);
			Assert.IsTrue(container?.Length > 0, "Value was empty");
		}
	}
}