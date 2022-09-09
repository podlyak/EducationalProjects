package com.labs.lab2.service;

import com.labs.lab2.model.Lesson;
import java.util.List;

public interface LessonService {
    void create(Lesson lesson);

    List<Lesson> readAll();

    Lesson read(int Id);

    boolean update(Lesson lesson, int Id);

    boolean delete(int Id);
}
