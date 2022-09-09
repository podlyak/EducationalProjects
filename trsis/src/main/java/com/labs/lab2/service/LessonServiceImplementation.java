package com.labs.lab2.service;

import com.labs.lab2.model.Lesson;
import org.springframework.stereotype.Service;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.concurrent.atomic.AtomicInteger;

@Service
public class LessonServiceImplementation implements LessonService {
    private static final Map<Integer, Lesson> LESSON_REPOSITORY_MAP = new HashMap<>();

    private static final AtomicInteger LESSON_ID_HOLDER = new AtomicInteger();

    @Override
    public void create(Lesson lesson) {
        final int lessonId = LESSON_ID_HOLDER.incrementAndGet();
        lesson.setId(lessonId);
        LESSON_REPOSITORY_MAP.put(lessonId, lesson);
    }

    @Override
    public List<Lesson> readAll() {
        return new ArrayList<>(LESSON_REPOSITORY_MAP.values());
    }

    @Override
    public Lesson read(int id) {
        return LESSON_REPOSITORY_MAP.get(id);
    }

    @Override
    public boolean update(Lesson lesson, int id) {
        if (LESSON_REPOSITORY_MAP.containsKey(id)) {
            lesson.setId(id);
            LESSON_REPOSITORY_MAP.put(id, lesson);
            return true;
        }

        return false;
    }

    @Override
    public boolean delete(int id) {
        return LESSON_REPOSITORY_MAP.remove(id) != null;
    }
}
