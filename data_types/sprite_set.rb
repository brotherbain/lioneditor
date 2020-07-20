# frozen_string_literal: true

# Copyright 2020, John Gaskin <brotherbain@gmail.com>
#
# This file is part of LionEditor.
#
# LionEditor is free software: you can redistribute it and/or modify
# it under the terms of the GNU General Public License as published by
# the Free Software Foundation, either version 3 of the License, or
# (at your option) any later version.
#
# LionEditor is distributed in the hope that it will be useful,
# but WITHOUT ANY WARRANTY; without even the implied warranty of
# MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
# GNU General Public License for more details.
#
# You should have received a copy of the GNU General Public License
# along with LionEditor.  If not, see <http://www.gnu.org/licenses/>.

require 'ostruct'
require 'yaml'

# Represents the entire sprite set, which affects characters' base job
class SpriteSet
  SPRITE_PATH = 'resources/sprites.yaml'

  class << self
    def all
      @all ||= begin
                 load_sprites
               rescue StandardError => e
                 puts 'could not load file'
                 puts e.inspect
               end
    end

    private

    def load_sprites
      File.open(SPRITE_PATH) do |file|
        entries = YAML.safe_load(file)

        parse_sprites_from(entries)
      end
    end

    def parse_sprites_from(entries)
      entries.each_with_object({}) do |entry, hash|
        obj = OpenStruct.new(entry)
        hash[obj.byte] = obj
      end
    end
  end
end
