import frida

class Callable:
    @staticmethod
    def on_message(message, data):
        print("[on_message] message:", message, "data:", data)

class InitCtx:
    def __init__(self,name):
        self.appname = name
        self.session = frida.attach(self.appname)

        self.script = self.session.create_script("""
        rpc.exports.enumerateModules = () => {
        return Process.enumerateModules();
        };
        """)

        self.script.on("message", Callable.on_message)
        self.script.load()

    def run(self):
        print([m["name"] for m in self.script.exports_sync.enumerate_modules()])