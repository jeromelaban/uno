namespace Microsoft.UI.Xaml {

	export class Application {
		private static dispatchVisibilityChangeAsync: (isVisible: boolean) => number;

		public static observeVisibility() {
			if (!Application.dispatchVisibilityChangeAsync) {
				if ((<any>globalThis).DotnetExports !== undefined) {
					Application.dispatchVisibilityChangeAsync = (<any>globalThis).DotnetExports.UnoUI.Microsoft.UI.Xaml.Application.DispatchVisibilityChangeAsync;
				} else {
					throw `Unable to find dotnet exports`;
				}
			}

			if (document.onvisibilitychange !== undefined) {
				document.addEventListener("visibilitychange", () => {
					Application.dispatchVisibilityChangeAsync(document.visibilityState == "visible");
				});
			}

			if (window.onpagehide !== undefined) {
				window.addEventListener("pagehide", () => {
					Application.dispatchVisibilityChangeAsync(false);
				});
			}

			if (window.onpageshow !== undefined) {
				window.addEventListener("pageshow", () => {
					Application.dispatchVisibilityChangeAsync(true);
				});
			}
		}
	}
}
