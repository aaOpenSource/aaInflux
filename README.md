aaInflux
=================

This application is a demonstration of how we can forward MXAccess data from Wonderware System Platform to the open source Influx Data time series historian with store/forward and **zero data loss**.

##InfluxDB/InfluxData
The InfluxData stack, also affectionately known as the TICK stack, is a collection of applications centered around the InfluxDB open source time series historian. Here are a couple links to help you read up on the project and get excited about the possibilities before you continue on.

[InfluxData](https://www.influxdata.com)

[InfluxDB on Github](https://github.com/influxdb/influxdb)

## Motivation

The pace of innovation in the Industrial historian space is notoriously slow.  While the major historian vendors do tend to have a decent feature set, the high cost and lack of velocity for new features has long been a source of frustration.  I have been following the InfluxDB project since the very early days.  I've watched it grow from what was ultimately a side project for a larger effort to a full blown stack with very real potential for usage in production systems.  

At this moment (late 2015) I think the stack might still be lacking in some features that would make it an acceptable replacement for a traditional historian.  However, I have no doubts if a decent community coalesced around the effort within about 6 months I think we could produce a historian that would be viable in a number of manufacturing environments.  Maybe 6 months to a year after that an you could look at the platform as a replacement in high reliability installations.

It's quite obvious that Paul Dix and the team at InfluxData are really sharp and apparently well funded.  I have little doubt they will keep up the pace of innovation and all we need to do is round out the feature set to make it a more familiar experience for users of traditional historians.

## Usage

First off, in it's current state, this is nothing more than a proof of concept.  I have one major feature implemented in a functional manner, store and forward, but there is a lot of work to turn this into a codeset that might be relied on for a real-world application.

To configure the application you need to define settings in two files.  

**MXAccess.json**
```json
{
  "subscribetags": [
    {
      "tag": "Sim_001.val[1]", "influxtag": "SIM_001_001"
    },
    {
      "tag": "Sim_001.val[2]"
    },
    {
      "tag": "Sim_001.val[3]"
    },
    { "tag": "Sim_001.val[4]" },
    { "tag": "Sim_001.val[5]" },
    { "tag": "Sim_001.val[6]" },
    { "tag": "Sim_001.val[7]" },
    { "tag": "Sim_001.val[8]" },
    { "tag": "Sim_001.val[9]" },
    { "tag": "Sim_001.val[10]" }
  ]
}

```

In this file you define the tags you wish to subscribe to via MXAccess.  The only requirement is that you are running the application on a node with a deployed platform.  Another feature is that you can explicitly define the InfluxDB tag you wish to use.  Currently I map `[`,`]`, and `.` to `_` to simplify tag retrieval on the Influx side.  Over time I think we can definitely improve this, probably with a regext pattern for replacement.

**influx.json**
```json
{
  "password": "aaInflux",
  "URL": "HTTP://192.168.120.1:8086",
  "userid": "aaInflux"
}
```

All of these items should be pretty obvious if you have an Influx stack up and running.

##Performance
So far I have only tested with 10 tags but testing with 500, 1000, and 10,000 tags is one of the most immediate priorities. 

## Platforms

The project is compiled against **.Net 4.5.2**.

All testing was performed against **Windows System Platform 2014R2 P01** and **InfluxDB 0.9.6.1** 

The vagrant file I used to the Influx and Grafana machine is located here [VAGRANT file](/vagrantfile) 

##Path Forward
For now I would like to implement a modest number of additional features before pausing and focusing on application stability so that it might be trusted in a production environment.

## Build Notes
No special build notes other than needing to restore Nuget packages on build. See the platofrms section above for specific versions.  

##Testing
No tests have been written yet.  This would be a nice project for someone to pickup.

##Chat Room

[![Join the chat at https://gitter.im/aaOpenSource/aaInflux](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/aaOpenSource/aaInflux)

## TODO List
Check out the [Issues](/../../issues) List

##Contributing
Check out the [Contributing](/CONTRIBUTING.MD) file

## Contributors

* [Andy Robinson](mailto:andy@phase2automation.com), Principal of [Phase 2 Automation](http://phase2automation.com).
* See list of [Contributors](/../../graphs/contributors) on the repo for others

## License

MIT License. See the [LICENSE file](/LICENSE) for details.
