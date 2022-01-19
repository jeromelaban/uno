namespace Windows.System {

	export class MemoryManager {

		static getAppMemoryUsage() {
			if (typeof Module === "function") {
				return (<any>Module).asm.memory.buffer.byteLength;
			}
			return -1;
		}
	}
}
