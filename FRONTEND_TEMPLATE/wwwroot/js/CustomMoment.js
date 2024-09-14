//To get the current date and time, just call moment() with no parameters.

var now = moment();

//Add time to current moment
moment().add(Number, String);
moment().add(7, 'days'); //parameters are days, months, years, hours, minutes, seconds, milliseconds

//Subtract time from current moment
moment().subtract(Number, String);
moment().subtract(7, 'days'); //parameters are days, months, years, hours, minutes, seconds, milliseconds

//Get the start of time
moment().startOf(String);
moment().startOf('year'); //parameters are day, month, year, hour, minute, second, millisecond

//Get the end of time
moment().endOf(String);
moment().endOf('year'); //parameters are day, month, year, hour, minute, second, millisecond

//Get the fime from another moment
moment().fromNow();
moment().fromNow('20111031'); //parameters are date, array