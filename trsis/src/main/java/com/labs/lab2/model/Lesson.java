package com.labs.lab2.model;

public class Lesson {
    private Integer id;
    private String title;
    private String weekday;
    private String type;
    private String auditorium;
    private String startTime;

    public void setId(Integer id) {
        this.id = id;
    }

    public Integer getId() {
        return id;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getTitle() {
        return title;
    }

    public void setWeekday(String weekday) {
        this.weekday = weekday;
    }

    public String getWeekday() {
        return weekday;
    }

    public void setType(String type) {
        this.type = type;
    }

    public String getType() {
        return type;
    }

    public void setAuditorium(String auditorium) {
        this.auditorium = auditorium;
    }

    public String getAuditorium() {
        return auditorium;
    }

    public void setStartTime(String startTime) {
        this.startTime = startTime;
    }

    public String getStartTime() {
        return startTime;
    }
}
