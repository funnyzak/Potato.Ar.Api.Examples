## Prepare the configuration environment

Configuration parameters will be retrieved from these sources in the listed order:

1. Command line arguments passed when running the example (E.g.: `APP_KEY=xyz`)
2. A properties file located in the root folder of the C# examples at `./examples.properties` (see `examples.properties` as reference)
3. Environment variables
4. A properties file located in the home folder at `~/examples.properties` (see `examples.properties.template` as reference)

Here is an example of an `examples.properties` file:

```bash
APP_KEY=your_key
APP_SECRET=your_secret
```

### How can I run an example?

#### Linux

Execute run_example.sh with the name of the desired [example](Potato.Ar.Example) as first parameter, followed by a list of configuration parameters if needed.

```bash
sh ./run-example.sh App APP_KEY=you-key APP_SECRET=you_secret

or

dotnet run App APP_KEY=you-key APP_SECRET=you_secret
dotnet run Account APP_KEY=you-key APP_SECRET=you_secret
```

#### Windows

Execute run_example.bat with the name of the desired [example](Potato.Ar.Example) as first parameter, followed by a list of configuration parameters if needed.

```bash
run-example.bat App APP_KEY=you-key APP_SECRET=you_secret
```
